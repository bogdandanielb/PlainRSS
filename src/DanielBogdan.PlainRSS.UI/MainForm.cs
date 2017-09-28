using DanielBogdan.PlainRSS.Core;
using DanielBogdan.PlainRSS.Core.Domain;
using DanielBogdan.PlainRSS.Core.DTOs;
using DanielBogdan.PlainRSS.Core.Logging;
using DanielBogdan.PlainRSS.Core.Theming;
using DanielBogdan.PlainRSS.UI.WinAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace DanielBogdan.PlainRSS.UI
{
    public partial class MainForm : Form
    {

        private static readonly Logger Logger =
            new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private Settings settings = new Settings();

        private readonly PreviewForm previewForm = new PreviewForm();

        private readonly BindingList<RssItem> rssItems = new BindingList<RssItem>();
        private readonly List<string> userAgents = new List<string>();
        private IList<Theme> themes;
        private Theme currentTheme;
        private RssListener listener = null;


        private bool isClosing = false;
        private int filteredCounter = 0;

        public MainForm()
        {
            InitializeComponent();
        }


        #region Menu events


        /// <summary>
        /// About menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog(this);
        }

        /// <summary>
        /// Exit menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClosing = true;
            Close();
        }


        /// <summary>
        /// Clear items menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (rssItems)
            {
                rssItems.Clear();
                filteredCounter = 0;
            }

            SetMainFormStatus();
        }



        /// <summary>
        /// Configure menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm { Settings = settings };
            settingsForm.ShowDialog(this);

            CreateTrayContextMenu();
        }

        /// <summary>
        /// start/stop the listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listener.IsRunning())
            {
                listener.Stop();

                startStopToolStripMenuItem.Text = @"Start";
                configureToolStripMenuItem.Enabled = true;
            }
            else
            {
                var ok = false;
                foreach (var rssCategory in settings.RssCategories)
                {
                    foreach (var rssWebsite in rssCategory.RssWebsites)
                    {
                        if (rssWebsite.Enabled)
                        {
                            ok = true;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    listener.Start();
                    startStopToolStripMenuItem.Text = @"Stop";
                    configureToolStripMenuItem.Enabled = false;
                }
                else
                    MessageBox.Show(this, @"There is no website enabled. Please check the configuration", @"Stopped",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion


        #region Context menu events 

        /// <summary>
        /// Always on top menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aotStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem == null)
                return;

            settings.AlwaysOnTop = toolStripMenuItem.Checked;
            TopMost = settings.AlwaysOnTop;
        }


        /// <summary>
        /// Contex menu enable/disable rss item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickWebsite(object sender, EventArgs e)
        {
            var toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem == null)
                return;

            var rssWebsite = toolStripMenuItem.Tag as RssWebsite;
            if (rssWebsite == null)
                return;

            rssWebsite.Enabled = !rssWebsite.Enabled;
            toolStripMenuItem.Checked = rssWebsite.Enabled;
        }


        #endregion


        #region Tray icon events


        /// <summary>
        /// Notify tray icon double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        /// <summary>
        /// Baloon clicked - open the url with default browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconTray_BalloonTipClicked(object sender, EventArgs e)
        {
            var item = notifyIconTray.Tag as RssItem;
            if (item != null && !string.IsNullOrWhiteSpace(item.Link))
            {
                try
                {
                    System.Diagnostics.Process.Start(item.Link);
                }
                catch (Exception exception)
                {
                    Logger.Error($"{nameof(notifyIconTray_BalloonTipClicked)} exception", exception);
                }
            }
        }

        #endregion


        #region Main form events

        /// <summary>
        /// Main form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {

            //Ignore server certificate check
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            rssItemBindingSource.DataSource = rssItems;

            previewForm.Visible = false;
            previewForm.Owner = this;


            userAgents.AddRange(Properties.Resources.UserAgents.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));



            var appDataPath = GetAppDataPath();

            themes = ThemeManager.LoadThemes(Path.Combine(appDataPath, "Themes"));
            currentTheme = themes[0];

            try
            {
                var settingsPersister = new SettingsPersister();
                settings = settingsPersister.ReadSettings(appDataPath);
            }
            catch (Exception exception)
            {
                Logger.Warn($"{nameof(MainForm_Load)} exception", exception);
            }


            //Start background worker
            listener = new RssListener(settings, userAgents);
            listener.NewRss += OnNewRss;


            startStopToolStripMenuItem_Click(null, EventArgs.Empty);

            CreateThemeMainMenu();

            CreateTrayContextMenu();

            ModifyMainFormStyle();

            InitHotKey();


        }



        private string GetAppDataPath()
        {

            var name = Assembly.GetEntryAssembly().GetName().Name;
            var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false))
                .Company;


            return
                Path.Combine(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), company), name);
        }

        /// <summary>
        /// Main form closing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                if (listener.IsRunning())
                    listener.Stop();

                try
                {
                    var settingsPersister = new SettingsPersister();
                    var name = Assembly.GetEntryAssembly().GetName().Name;
                    var company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
                            Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false))
                        .Company;

                    settingsPersister.SaveSettings(settings,
                        Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), company), name));
                }
                catch (Exception exception)
                {
                    Logger.Warn($"{nameof(MainForm_FormClosing)} exception", exception);
                }


                notifyIconTray.Dispose();
            }
        }

        #endregion


        private void ModifyMainFormStyle()
        {
            var assembly = Assembly.GetEntryAssembly().GetName();
            Text = $@"{assembly.Name} {assembly.Version}";

            Opacity = settings.Opacity;
            TopMost = settings.AlwaysOnTop;

            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;


            Location = new Point(screenWidth - this.Size.Width, 0);
            Size = new Size(this.Size.Width, screenHeight);
        }

        private void SetMainFormStatus()
        {
            this.toolStripStatusLabel.Text =
                $@"{this.listBoxItems.Items.Count} projects. {filteredCounter} filtered.";
        }

        private void InitHotKey()
        {
            //hotkey init for showing
            var key = new HotKey
            {
                KeyModifier = HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Control,
                Key = Keys.C
            };

            key.HotKeyPressed += new System.Windows.Forms.KeyEventHandler(hotkey_HotKeyPressed);
            //end
        }

        private void hotkey_HotKeyPressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.Visible = true;
        }

        private void CreateTrayContextMenu()
        {
            contextMenuStripTray.Items.Clear();


            foreach (var rssCategory in settings.RssCategories)
            {
                var toolStripMenuItem = new ToolStripMenuItem(rssCategory.Name);

                foreach (var rssWeb in rssCategory.RssWebsites)
                {
                    var childToolStripMenuItem = new ToolStripMenuItem(rssWeb.Name);
                    childToolStripMenuItem.Click += new EventHandler(OnClickWebsite);
                    childToolStripMenuItem.Checked = rssWeb.Enabled;
                    childToolStripMenuItem.Tag = rssWeb;

                    toolStripMenuItem.DropDownItems.Add(childToolStripMenuItem);
                }

                contextMenuStripTray.Items.Add(toolStripMenuItem);
            }

            var aotMenuItem = new ToolStripMenuItem("Always On Top")
            {
                Checked = settings.AlwaysOnTop,
                CheckOnClick = true
            };
            aotMenuItem.Click += new EventHandler(aotStripMenuItem_Click);
            contextMenuStripTray.Items.Add(aotMenuItem);

            var clearMenuItem = new ToolStripMenuItem("Clear", Properties.Resources.ic_delete_black_24dp_1x)
            {
                CheckOnClick = false
            };
            clearMenuItem.Click += (sender, args) => clearToolStripMenuItem_Click(null, null);
            contextMenuStripTray.Items.Add(clearMenuItem);

            var exitMenuItem = new ToolStripMenuItem("Exit", Properties.Resources.exit,
                new EventHandler(exitToolStripMenuItem_Click));
            exitMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            contextMenuStripTray.Items.Add(exitMenuItem);
        }



        private void CreateThemeMainMenu()
        {
            //TODO: Implement theming 
        }


        /// <summary>
        /// NewRss event handler
        /// </summary>
        /// <param name="rssItem"></param>
        private void OnNewRss(RssItem rssItem)
        {
            if (!InvokeRequired)
            {
                if (!rssItem.Website.FirstUpdate)
                {
                    if (rssItems.Contains(rssItem))
                        return;


                    if (settings.IgnoreEnabled)
                    {
                        if (IsFilteredOut(rssItem))
                        {
                            Logger.Info($"{nameof(OnNewRss)} filtered out \"{rssItem.Title}\" pub date {rssItem.PubDate} link {rssItem.Link}");

                            filteredCounter++;
                            SetMainFormStatus();
                            return;
                        }
                    }

                    lock (rssItems)
                    {
                        rssItems.Insert(0, rssItem);
                        if (this.rssItems.Count > settings.MaxHistoryItems)
                            this.rssItems.RemoveAt(rssItems.Count - 1);
                    }

                    Logger.Info($"{nameof(OnNewRss)} shown item \"{rssItem.Title}\" pub date {rssItem.PubDate} link {rssItem.Link}");

                    SetMainFormStatus();

                    notifyIconTray.Tag = rssItem;


                    this.notifyIconTray.ShowBalloonTip(0,
                                                        $"{rssItem.Title}",
                                                        string.Join("\r\n", Utilities.WrapTextByCharacterNoFull(rssItem.Description, 100)),
                                                        ToolTipIcon.Info);
                }
            }
            else
            {
                Invoke(new Action<RssItem>(OnNewRss), new object[] { rssItem });
            }
        }

        /// <summary>
        /// Check if the filter regex matches item title or description 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool IsFilteredOut(RssItem item)
        {
            foreach (string filter in settings.IgnoredItems.Split(new string[] { "\n" },
                StringSplitOptions.RemoveEmptyEntries))
            {
                if (Regex.IsMatch(item.Title, filter.Trim(), RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(item.Description, filter.Trim(), RegexOptions.IgnoreCase))
                    return true;
            }

            return false;
        }


        #region Rss Items list events

        /// <summary>
        /// Ownerdraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            var backColor = e.BackColor;


            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            switch (e.Index % 2)
            {
                case 0:
                    backColor = Color.FromArgb(255, 60, 60, 60);
                    break;
                    //case 1:
                    //    backColor = Color.Orange;
                    //    break;
            }

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds /*new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width, e.Bounds.Height * 2)) */, e.Index,
                    e.State,
                    e.ForeColor, Color.DarkGray);
            // Draw the background of the ListBox control for each item based on above selection
            else
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index,
                    e.State,
                    e.ForeColor, backColor);

            e.DrawBackground();


            Image image = Properties.Resources.feed_icon_grey_24px;
            var point = new Point(e.Bounds.X + 10, e.Bounds.Y + 10);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                image = Properties.Resources.feed_icon_orange_24px;

            if (e.Index >= 0 && image != null)
                e.Graphics.DrawImage(image, point);

            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            point = new Point(e.Bounds.X + 50, e.Bounds.Y + 10);

            if (e.Index >= 0)
            {
                var rssItem = this.listBoxItems.Items[e.Index] as RssItem;
                if (rssItem == null)
                    return;

                using (var largerFont = new Font(e.Font, FontStyle.Regular))
                {
                    var toDraw =
                        $"{(rssItem.PubDate.Date == DateTime.Today ? "Today, " + rssItem.PubDate.ToString("hh:mm") : rssItem.PubDate.ToString("dddd, hh:mm"))}";
                    var drawWidth = e.Graphics.MeasureString(toDraw, largerFont).Width;

                    e.Graphics.DrawString(toDraw,
                        largerFont, new SolidBrush(e.ForeColor), point, StringFormat.GenericDefault);

                    point.Offset((int)drawWidth, 0);

                    using (var largerBoldFont = new Font(e.Font, FontStyle.Bold))
                    {
                        var color = ColorTranslator.FromHtml(rssItem.Category.Color);
                        e.Graphics.DrawString($" {rssItem.Category.Name} {rssItem.Website.Name}",
                            largerBoldFont, new SolidBrush(color), point, StringFormat.GenericDefault);

                        point.Offset(-1 * (int)drawWidth, largerFont.Height);
                    }

                }

                using (var largerFont = new Font(e.Font.FontFamily, 14, FontStyle.Bold))
                {
                    e.Graphics.DrawString(rssItem.Title,
                        largerFont, new SolidBrush(e.ForeColor), point, StringFormat.GenericDefault);

                    point.Offset(0, largerFont.Height);
                }


                var lines = UIUtilities.WrapTextByPixelSize(rssItem.Description, e.Bounds.Width, e.Graphics, e.Font);
                //Draw the first two lines only
                e.Graphics.DrawString(lines[0],
                    e.Font, new SolidBrush(e.ForeColor), point, StringFormat.GenericDefault);

                point.Offset(0, e.Font.Height);
                if (lines.Count > 1)
                    e.Graphics.DrawString(lines[1] + "...",
                        e.Font, new SolidBrush(e.ForeColor), point, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }


        /// <summary>
        /// Listbox tem double clicked open URL in defaul browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItems_DoubleClick(object sender, EventArgs e)
        {
            var item = this.listBoxItems.SelectedItem as RssItem;
            if (item != null && !string.IsNullOrWhiteSpace(item.Link))
            {
                try
                {
                    System.Diagnostics.Process.Start(item.Link);
                }
                catch (Exception exception)
                {
                    Logger.Error($"{nameof(listBoxItems_DoubleClick)} exception", exception);
                }
            }
        }

        /// <summary>
        /// Show Context menu for listbox right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItems_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = new Point(e.X, e.Y);
                var index = this.listBoxItems.IndexFromPoint(point);
                if (index < 0 || index >= listBoxItems.Items.Count)
                    return;

                this.listBoxItems.SelectedIndex = index;
                this.contextMenuStripList.Show(listBoxItems, point);
            }
        }



        /// <summary>
        /// Delete and Enter key handler for list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0 || listBoxItems.SelectedIndex >= rssItems.Count)
                return;


            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        lock (rssItems)
                        {
                            rssItems.RemoveAt(listBoxItems.SelectedIndex);
                        }

                        break;
                    }
                case Keys.Enter:
                    {
                        listBoxItems_DoubleClick(null, EventArgs.Empty);
                        break;
                    }
            }
        }

        /// <summary>
        /// Refresh listbox items on resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItems_Resize(object sender, EventArgs e)
        {
            //Force redraw all items in the list when resized
            this.listBoxItems.Invalidate();
        }


        /// <summary>
        /// Preview item using builtin WebBrowser control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rssItem = listBoxItems.SelectedItem as RssItem;
            if (rssItem == null)
                return;


            previewForm.Link = rssItem.Link;
            previewForm.ShowDialog(this);
        }

        #endregion
    }
}