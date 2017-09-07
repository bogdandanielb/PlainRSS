using DanielBogdan.PlainRSS.Core.DTOs;

namespace DanielBogdan.PlainRSS.UI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAOT = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownMaxRss = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteSubgroup = new System.Windows.Forms.Button();
            this.buttonEditSubgroup = new System.Windows.Forms.Button();
            this.buttonNewSubgroup = new System.Windows.Forms.Button();
            this.buttonDeleteGroup = new System.Windows.Forms.Button();
            this.buttonEditGroup = new System.Windows.Forms.Button();
            this.buttonNewGroup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxRSS = new System.Windows.Forms.ListBox();
            this.subgroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.groupControl1 = new System.Windows.Forms.GroupBox();
            this.textBoxIgnoreItems = new System.Windows.Forms.TextBox();
            this.checkBoxIgnore = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRss)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subgroupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAOT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBarOpacity);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // checkBoxAOT
            // 
            this.checkBoxAOT.Location = new System.Drawing.Point(21, 67);
            this.checkBoxAOT.Name = "checkBoxAOT";
            this.checkBoxAOT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxAOT.Size = new System.Drawing.Size(92, 19);
            this.checkBoxAOT.TabIndex = 2;
            this.checkBoxAOT.Text = "Always on top";
            this.checkBoxAOT.CheckedChanged += new System.EventHandler(this.checkBoxAOT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity:";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(84, 27);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 10;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(308, 45);
            this.trackBarOpacity.TabIndex = 0;
            this.trackBarOpacity.Value = 100;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(315, 434);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(98, 33);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max rss items:";
            // 
            // numericUpDownMaxRss
            // 
            this.numericUpDownMaxRss.BackColor = System.Drawing.Color.Ivory;
            this.numericUpDownMaxRss.Location = new System.Drawing.Point(136, 32);
            this.numericUpDownMaxRss.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaxRss.Name = "numericUpDownMaxRss";
            this.numericUpDownMaxRss.Size = new System.Drawing.Size(209, 20);
            this.numericUpDownMaxRss.TabIndex = 4;
            this.numericUpDownMaxRss.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownDelay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonDeleteSubgroup);
            this.groupBox2.Controls.Add(this.buttonEditSubgroup);
            this.groupBox2.Controls.Add(this.buttonNewSubgroup);
            this.groupBox2.Controls.Add(this.buttonDeleteGroup);
            this.groupBox2.Controls.Add(this.buttonEditGroup);
            this.groupBox2.Controls.Add(this.buttonNewGroup);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numericUpDownMaxRss);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.listBoxRSS);
            this.groupBox2.Controls.Add(this.listBoxCategory);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 310);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RSS";
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.BackColor = System.Drawing.Color.Ivory;
            this.numericUpDownDelay.Location = new System.Drawing.Point(136, 62);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(209, 20);
            this.numericUpDownDelay.TabIndex = 14;
            this.numericUpDownDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Delay (sec):";
            // 
            // buttonDeleteSubgroup
            // 
            this.buttonDeleteSubgroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDeleteSubgroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteSubgroup.Image")));
            this.buttonDeleteSubgroup.Location = new System.Drawing.Point(305, 129);
            this.buttonDeleteSubgroup.Name = "buttonDeleteSubgroup";
            this.buttonDeleteSubgroup.Size = new System.Drawing.Size(40, 35);
            this.buttonDeleteSubgroup.TabIndex = 12;
            this.buttonDeleteSubgroup.Click += new System.EventHandler(this.buttonDeleteRSS_Click);
            // 
            // buttonEditSubgroup
            // 
            this.buttonEditSubgroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonEditSubgroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditSubgroup.Image")));
            this.buttonEditSubgroup.Location = new System.Drawing.Point(259, 129);
            this.buttonEditSubgroup.Name = "buttonEditSubgroup";
            this.buttonEditSubgroup.Size = new System.Drawing.Size(40, 35);
            this.buttonEditSubgroup.TabIndex = 11;
            this.buttonEditSubgroup.Click += new System.EventHandler(this.buttonEditRSS_Click);
            // 
            // buttonNewSubgroup
            // 
            this.buttonNewSubgroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonNewSubgroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNewSubgroup.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.new_window;
            this.buttonNewSubgroup.Location = new System.Drawing.Point(213, 129);
            this.buttonNewSubgroup.Name = "buttonNewSubgroup";
            this.buttonNewSubgroup.Size = new System.Drawing.Size(40, 35);
            this.buttonNewSubgroup.TabIndex = 10;
            this.buttonNewSubgroup.Click += new System.EventHandler(this.buttonNewRSS_Click);
            // 
            // buttonDeleteGroup
            // 
            this.buttonDeleteGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteGroup.Image")));
            this.buttonDeleteGroup.Location = new System.Drawing.Point(110, 129);
            this.buttonDeleteGroup.Name = "buttonDeleteGroup";
            this.buttonDeleteGroup.Size = new System.Drawing.Size(40, 35);
            this.buttonDeleteGroup.TabIndex = 9;
            this.buttonDeleteGroup.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonEditGroup
            // 
            this.buttonEditGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditGroup.Image")));
            this.buttonEditGroup.Location = new System.Drawing.Point(64, 129);
            this.buttonEditGroup.Name = "buttonEditGroup";
            this.buttonEditGroup.Size = new System.Drawing.Size(40, 35);
            this.buttonEditGroup.TabIndex = 8;
            this.buttonEditGroup.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // buttonNewGroup
            // 
            this.buttonNewGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonNewGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNewGroup.Image = global::DanielBogdan.PlainRSS.UI.Properties.Resources.new_window;
            this.buttonNewGroup.Location = new System.Drawing.Point(18, 129);
            this.buttonNewGroup.Name = "buttonNewGroup";
            this.buttonNewGroup.Size = new System.Drawing.Size(40, 35);
            this.buttonNewGroup.TabIndex = 7;
            this.buttonNewGroup.Click += new System.EventHandler(this.buttonNewCategory_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "RSS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category:";
            // 
            // listBoxRSS
            // 
            this.listBoxRSS.BackColor = System.Drawing.Color.Ivory;
            this.listBoxRSS.DataSource = this.subgroupsBindingSource;
            this.listBoxRSS.DisplayMember = "Name";
            this.listBoxRSS.FormattingEnabled = true;
            this.listBoxRSS.Location = new System.Drawing.Point(213, 170);
            this.listBoxRSS.Name = "listBoxRSS";
            this.listBoxRSS.Size = new System.Drawing.Size(181, 134);
            this.listBoxRSS.TabIndex = 1;
            this.listBoxRSS.ValueMember = "Name";
            // 
            // subgroupsBindingSource
            // 
            this.subgroupsBindingSource.DataMember = "RssWebsites";
            this.subgroupsBindingSource.DataSource = this.groupsBindingSource;
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataMember = "RssCategories";
            this.groupsBindingSource.DataSource = typeof(DanielBogdan.PlainRSS.Core.DTOs.Settings);
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.BackColor = System.Drawing.Color.Ivory;
            this.listBoxCategory.DataSource = this.groupsBindingSource;
            this.listBoxCategory.DisplayMember = "Name";
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.Location = new System.Drawing.Point(18, 170);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(181, 134);
            this.listBoxCategory.TabIndex = 0;
            this.listBoxCategory.ValueMember = "Name";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textBoxIgnoreItems);
            this.groupControl1.Controls.Add(this.checkBoxIgnore);
            this.groupControl1.Location = new System.Drawing.Point(429, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(288, 422);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.TabStop = false;
            this.groupControl1.Text = "Filter";
            // 
            // textBoxIgnoreItems
            // 
            this.textBoxIgnoreItems.BackColor = System.Drawing.Color.Ivory;
            this.textBoxIgnoreItems.Location = new System.Drawing.Point(9, 50);
            this.textBoxIgnoreItems.Multiline = true;
            this.textBoxIgnoreItems.Name = "textBoxIgnoreItems";
            this.textBoxIgnoreItems.Size = new System.Drawing.Size(270, 366);
            this.textBoxIgnoreItems.TabIndex = 3;
            // 
            // checkBoxIgnore
            // 
            this.checkBoxIgnore.Location = new System.Drawing.Point(7, 24);
            this.checkBoxIgnore.Name = "checkBoxIgnore";
            this.checkBoxIgnore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIgnore.Size = new System.Drawing.Size(192, 19);
            this.checkBoxIgnore.TabIndex = 2;
            this.checkBoxIgnore.Text = "Filter out items containing (Regex)";
            this.checkBoxIgnore.CheckedChanged += new System.EventHandler(this.checkBoxIgnore_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 477);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::DanielBogdan.PlainRSS.UI.Properties.Resources.rssico;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRss)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subgroupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxAOT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRss;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDeleteGroup;
        private System.Windows.Forms.Button buttonEditGroup;
        private System.Windows.Forms.Button buttonNewGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxRSS;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.Button buttonDeleteSubgroup;
        private System.Windows.Forms.Button buttonEditSubgroup;
        private System.Windows.Forms.Button buttonNewSubgroup;
        private System.Windows.Forms.BindingSource subgroupsBindingSource;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupControl1;
        private System.Windows.Forms.TextBox textBoxIgnoreItems;
        private System.Windows.Forms.CheckBox checkBoxIgnore;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}