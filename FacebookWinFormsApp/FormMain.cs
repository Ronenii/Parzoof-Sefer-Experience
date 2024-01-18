using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.session;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public SessionManager SessionManager { get; set; }
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            SessionManager = new SessionManager();

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
                initAllComponents();
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

        private void initAllComponents()
        {

        }

        private void linkTimeline_MouseClick(object sender, MouseEventArgs e)
        {
            fetchTimeline();
        }

        private void fetchTimeline()
        {
            if(listBoxTimeline.Items.Count != 0)
            {
                listBoxTimeline.Items.Clear();
            }
            
            foreach(Post timelinePost in SessionManager.User.NewsFeed)
            {
                if(timelinePost.Message != null)
                {
                    listBoxTimeline.Items.Add(timelinePost.Message);
                }
                else if(timelinePost.Caption != null)
                {
                    listBoxTimeline.Items.Add(timelinePost.Caption);
                }

                if (listBoxTimeline.Items.Count == 0)
                {
                    MessageBox.Show("The timeline is up to date.");
                }
            }

        }

        private void listBoxTimeline_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selected = SessionManager.User.Posts[listBoxTimeline.SelectedIndex];
            listBoxComments.DisplayMember = "Message";
            listBoxComments.DataSource = selected.Comments;
        }

        private void buttonPost_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBoxStatus.Text))
                {
                    MessageBox.Show("Please enter a status");
                }
                else
                {
                    SessionManager.User.PostStatus(textBoxStatus.Text);
                    MessageBox.Show("Status posted!");
                    textBoxStatus.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
