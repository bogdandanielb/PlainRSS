using DanielBogdan.PlainRSS.Core.Domain;
using System;
using System.Drawing;
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
            rssCategory.Color = ColorTranslator.ToHtml(this.labelColor.BackColor);
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
            this.labelColor.BackColor = ColorTranslator.FromHtml(RssCategory.Color);
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            colorDialogPicker.Color = this.labelColor.BackColor;
            colorDialogPicker.FullOpen = true;
            if (colorDialogPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.labelColor.BackColor = colorDialogPicker.Color;
            }
        }
    }
}