#region Namespaces

using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion // Namespaces

namespace HideInternalOriginEverywhere.UI
{
    public partial class DefaultProgressForm : Form
    {
        string _format;
        string _toolTitle;
        private bool abortFlag;
        /// <summary>
        /// Set up progress bar form and immediately display it modelessly.
        /// </summary>
        /// <param name="caption">Form caption</param>
        /// <param name="format">Progress message string</param>
        /// <param name="toolTitle">Name of the tool.</param>
        /// <param name="max">Number of elements to process</param>
        public DefaultProgressForm(string caption, string format, string toolTitle, int max)
        {

            _format = format;
            _toolTitle = toolTitle;
            InitializeComponent();
            CenterToScreen();
            Text = caption;
            label1.Text = (null == format) ? caption : string.Format(format, 1);
            label4.Text = toolTitle;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;
            progressBar1.Value = 0;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            Show();
            Application.DoEvents();

        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public void ShowResults()
        {
            //this.progressBar1.Hide();
            this.label1.Text = "We have succesfully hid the internal origin in " + progressBar1.Maximum + " views.";
        }

        public void Increment()
        {
            ++progressBar1.Value;
            if (null != _format)
            {
                label1.Text = string.Format(_format, progressBar1.Value);
            }
            Application.DoEvents();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("IExplore.exe", "https://www.parallaxteam.com/");
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        
    }
}
