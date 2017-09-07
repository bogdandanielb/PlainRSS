using System.Windows.Forms;

namespace DanielBogdan.PlainRSS.UI
{
    public partial class PreviewForm : Form
    {

        private string link = "about:blank";

        public string Link
        {
            get { return link; }
            set
            {
                link = value;
                webBrowser.Navigate(link);
            }
        }


        public PreviewForm()
        {
            InitializeComponent();
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void webBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Cancel any popup window
            e.Cancel = true;
        }
    }
}