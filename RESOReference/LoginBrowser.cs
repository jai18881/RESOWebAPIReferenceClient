using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESOReference
{
    public delegate void Navigate(Uri uri);
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class LoginBrowser : Form
    {
        public Navigate navigateurl;

        public LoginBrowser()
        {
            InitializeComponent();

        }

        public void SetURL(string url, Navigate nav)
        {
            navigateurl = nav;
            webBrowser1.Navigate(new Uri(url));
        }
        private void Browser_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

            if (e.Url.AbsoluteUri.IndexOf("code=") >= 0)
            {
                int tweet = e.Url.AbsoluteUri.IndexOf("#");
                if (tweet >= 0)
                {

                    string codeurl = e.Url.AbsoluteUri.Substring(tweet + 1, e.Url.AbsoluteUri.Length - tweet - 1);
                    navigateurl(new Uri(codeurl));
                }
                else
                {
                    navigateurl(e.Url);
                }
                this.Close();
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsoluteUri.IndexOf("code=") >= 0)
            {
                int tweet = e.Url.AbsoluteUri.IndexOf("#");
                if (tweet >= 0)
                {

                    string codeurl = e.Url.AbsoluteUri.Substring(tweet + 1, e.Url.AbsoluteUri.Length - tweet - 1);
                    navigateurl(new Uri(codeurl));
                }
                else
                {
                    navigateurl(e.Url);
                }
                this.Close();
            }
        }
    }
}
