using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.session;
using BasicFacebookFeatures.serialization;
using System.IO;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public SessionManager SessionManager { get; set; }
        public AppSettings AppSettings { get; set; }
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            SessionManager = new SessionManager();
        }

        protected override void OnShown(EventArgs e)
        {
            AppSettings = AppSettings.LoadFromFile();
            if(AppSettings.RememberUser && !string.IsNullOrEmpty(AppSettings.LastAccessToken))
            {
                SessionManager.LoginFromAppSettings(AppSettings.LastAccessToken);
                checkBoxRemember.Checked = true;
                adjustUiToLoggedInUser();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            AppSettings.LastWindowSize = this.Size;
            AppSettings.LastWindowLocation = this.Location;
            AppSettings.RememberUser = this.checkBoxRemember.Checked;
            if(AppSettings.RememberUser)
            {
                AppSettings.LastAccessToken = SessionManager.AccessToken;
            }

            AppSettings.SaveToFile();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            SessionManager.login();

            if (SessionManager.LoginResult != null)
            {
                adjustUiToLoggedInUser();
            }
        }

        private void adjustUiToLoggedInUser()
        {
            if(SessionManager.AccessToken != null)
            {
                pictureBoxProfile.ImageLocation = SessionManager.User.PictureNormalURL;
                labelName.Text = SessionManager.User.Name;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
            }
            else
            {
                SessionManager.LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            SessionManager = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.Image = null;
            labelName.Text = "-";
        }

    }
}
