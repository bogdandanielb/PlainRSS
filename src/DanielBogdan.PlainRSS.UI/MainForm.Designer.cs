namespace DanielBogdan.PlainRSS.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.rssItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rssItemBindingSource)).BeginInit();
            this.contextMenuStripList.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.startStopToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.advancedsettings;
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.configureToolStripMenuItem.Text = "Configure...";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // startStopToolStripMenuItem
            // 
            this.startStopToolStripMenuItem.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.advanced;
            this.startStopToolStripMenuItem.Name = "startStopToolStripMenuItem";
            this.startStopToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.startStopToolStripMenuItem.Text = "Start";
            this.startStopToolStripMenuItem.Click += new System.EventHandler(this.startStopToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.agt_web;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(581, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // listBoxItems
            // 
            this.listBoxItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listBoxItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxItems.DataSource = this.rssItemBindingSource;
            this.listBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxItems.ForeColor = System.Drawing.Color.White;
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.IntegralHeight = false;
            this.listBoxItems.ItemHeight = 100;
            this.listBoxItems.Location = new System.Drawing.Point(0, 24);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(581, 601);
            this.listBoxItems.TabIndex = 2;
            this.listBoxItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxItems_DrawItem);
            this.listBoxItems.DoubleClick += new System.EventHandler(this.listBoxItems_DoubleClick);
            this.listBoxItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxItems_KeyUp);
            this.listBoxItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxItems_MouseUp);
            this.listBoxItems.Resize += new System.EventHandler(this.listBoxItems_Resize);
            // 
            // rssItemBindingSource
            // 
            this.rssItemBindingSource.DataSource = typeof(DanielBogdan.PlainRSS.Core.Domain.RssItem);
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconTray.Icon = global::DanielBogdan.PlainRSS.UI.Properties.Resources.rssico;
            this.notifyIconTray.Text = "PlainRSS";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.BalloonTipClicked += new System.EventHandler(this.notifyIconTray_BalloonTipClicked);
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Name = "contextMenuStrip_addSource";
            this.contextMenuStripTray.Size = new System.Drawing.Size(61, 4);
            // 
            // toolTipMain
            // 
            this.toolTipMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolTipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // contextMenuStripList
            // 
            this.contextMenuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem});
            this.contextMenuStripList.Name = "contextMenuStripList";
            this.contextMenuStripList.Size = new System.Drawing.Size(116, 26);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.ic_delete_black_24dp_1x;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 647);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = global::DanielBogdan.PlainRSS.UI.Properties.Resources.rssico;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlainRSS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rssItemBindingSource)).EndInit();
            this.contextMenuStripList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.BindingSource rssItemBindingSource;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripList;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

