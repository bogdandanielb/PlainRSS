using DanielBogdan.PlainRSS.Core.Domain;
using DanielBogdan.PlainRSS.Core.DTOs;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DanielBogdan.PlainRSS.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public Settings Settings { get; set; }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            ((MainForm)Owner).Opacity = trackBarOpacity.Value / 100.0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void checkBoxAOT_CheckedChanged(object sender, EventArgs e)
        {
            ((MainForm)Owner).TopMost = checkBoxAOT.Checked;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            groupsBindingSource.DataSource = Settings;
            trackBarOpacity.Value = (int)(((MainForm)Owner).Opacity * 100);
            checkBoxAOT.Checked = ((MainForm)Owner).TopMost;
            numericUpDownMaxRss.Value = Settings.MaxHistoryItems;
            numericUpDownDelay.Value = Settings.Delay;
            checkBoxIgnore.Checked = Settings.IgnoreEnabled;
            textBoxIgnoreItems.Text = Settings.IgnoredItems;

            checkBoxIgnore_CheckedChanged(null, null);
        }


        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidateInputs())
            {
                e.Cancel = true;
                return;
            }

            Settings.MaxHistoryItems = (int)numericUpDownMaxRss.Value;
            Settings.AlwaysOnTop = checkBoxAOT.Checked;
            Settings.Opacity = trackBarOpacity.Value / 100.0;
            Settings.Delay = (int)numericUpDownDelay.Value;
            Settings.IgnoreEnabled = checkBoxIgnore.Checked;
            Settings.IgnoredItems = textBoxIgnoreItems.Text;
        }

        private bool ValidateInputs()
        {
            var validInputs = true;

            foreach (string filter in this.textBoxIgnoreItems.Text.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries))
            {
                if (!IsValidRegex(filter))
                {
                    validInputs = false;
                    this.errorProvider1.SetError(this.textBoxIgnoreItems, $"Invalid regular expression: {filter}");
                    break;
                }
            }


            return validInputs;
        }

        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            var rssg = new RssCategory();

            var groupForm = new CategoryForm { RssCategory = rssg };

            if (groupForm.ShowDialog(this) == DialogResult.OK)
                Settings.RssCategories.Add(rssg);
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            var rssCategory = listBoxCategory.SelectedItem as RssCategory;
            if (rssCategory == null)
                return;

            var groupForm = new CategoryForm
            {
                RssCategory = rssCategory
            };

            groupForm.ShowDialog(this);

            groupsBindingSource.ResetBindings(false);
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            var rssCategory = listBoxCategory.SelectedItem as RssCategory;
            if (rssCategory == null)
                return;

            Settings.RssCategories.Remove(rssCategory);
        }

        private void buttonNewRSS_Click(object sender, EventArgs e)
        {
            var rssCategory = listBoxCategory.SelectedItem as RssCategory;
            if (rssCategory == null)
                return;

            var rssWebsite = new RssWebsite();

            var subgroupForm = new RSSForm
            {
                RssWebsite = rssWebsite
            };

            if (subgroupForm.ShowDialog(this) == DialogResult.OK)
                rssCategory.RssWebsites.Add(rssWebsite);
        }

        private void buttonEditRSS_Click(object sender, EventArgs e)
        {
            var rssWebsite = listBoxRSS.SelectedItem as RssWebsite;
            if (rssWebsite == null)
                return;

            var subgroupForm = new RSSForm
            {
                RssWebsite = rssWebsite
            };

            subgroupForm.ShowDialog(this);

            subgroupsBindingSource.ResetBindings(false);
        }

        private void buttonDeleteRSS_Click(object sender, EventArgs e)
        {
            var rssCategory = listBoxCategory.SelectedItem as RssCategory;
            if (rssCategory == null)
                return;

            var rssWebsite = listBoxRSS.SelectedItem as RssWebsite;
            if (rssWebsite == null)
                return;

            rssCategory.RssWebsites.Remove(rssWebsite);
        }

        private void checkBoxIgnore_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIgnoreItems.Enabled = checkBoxIgnore.Checked;
        }


        private static bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}