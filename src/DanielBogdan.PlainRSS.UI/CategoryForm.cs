using DanielBogdan.PlainRSS.Core.Domain;
using System;
using System.Windows.Forms;

namespace DanielBogdan.PlainRSS.UI
{
    public partial class CategoryForm : Form
    {

        private RssCategory rssCategory;

        public RssCategory RssCategory
        {
            get { return rssCategory; }
            set { rssCategory = value; }
        }


        public CategoryForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            rssCategory.Name = this.textBoxName.Text;
            DialogResult = DialogResult.OK;
        }

        private bool VerifyFields()
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            var ok = true;

            if (string.IsNullOrEmpty(this.textBoxName.Text))
            {
                errorProvider1.SetError(this.textBoxName, "The name field is empty");
                ok = false;
            }

            return ok;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            this.textBoxName.Text = rssCategory.Name;
        }
    }
}