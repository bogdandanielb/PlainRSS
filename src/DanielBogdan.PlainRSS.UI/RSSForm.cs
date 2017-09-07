using DanielBogdan.PlainRSS.Core.Domain;
using System;
using System.Windows.Forms;

namespace DanielBogdan.PlainRSS.UI
{
    public partial class RSSForm : Form
    {

        private RssWebsite rssWebsite;

        public RssWebsite RssWebsite
        {
            get { return rssWebsite; }
            set { rssWebsite = value; }
        }


        public RSSForm()
        {
            InitializeComponent();
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            rssWebsite.Name = this.textBoxName.Text;
            rssWebsite.Link = this.textBoxLink.Text;
            rssWebsite.Enabled = this.checkBoxEnable.Checked;
            DialogResult = DialogResult.OK;
        }

        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            var isValid = true;

            if (string.IsNullOrEmpty(this.textBoxName.Text))
            {
                errorProvider1.SetError(this.textBoxName, "The name field is empty");
                isValid = false;
            }

            if (string.IsNullOrEmpty(this.textBoxLink.Text))
            {
                errorProvider2.SetError(this.textBoxLink, "The link field is empty");
                isValid = false;
            }

            if (!Uri.IsWellFormedUriString(this.textBoxLink.Text, UriKind.RelativeOrAbsolute))
            {
                errorProvider2.SetError(this.textBoxLink, "The link field is invalid");
                isValid = false;
            }

            return isValid;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SubgroupForm_Load(object sender, EventArgs e)
        {
            this.textBoxName.Text = rssWebsite.Name;
            this.textBoxLink.Text = rssWebsite.Link;
            this.checkBoxEnable.Checked = rssWebsite.Enabled;
        }
    }
}