using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.session;
using BasicFacebookFeatures.logic.grid;
using BasicFacebookFeatures.serialization;


namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public SessionManager SessionManager { get; set; }
        public AppSettings AppSettings { get; set; }
        private FacebookObjectDisplayGrid<Album> m_AlbumsGrid;
        private FacebookObjectDisplayGrid<User> m_FriendsGrid;
        private FacebookObjectDisplayGrid<Page> m_PagesGrid;
        private int m_PreviousNumberOfAlbums;
        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
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

            m_PreviousNumberOfAlbums = 0;
        }

        private void initTabs()
        {
            m_AlbumsGrid = new FacebookObjectDisplayGrid<Album>(SessionManager.UserWrapper.GetAlbums, this);
            tabAlbums.Controls.Add(m_AlbumsGrid.Grid);

            m_FriendsGrid = new FacebookObjectDisplayGrid<User>(SessionManager.UserWrapper.GetFriends, this);
            tabFriends.Controls.Add(m_FriendsGrid.Grid);

            m_PagesGrid = new FacebookObjectDisplayGrid<Page>(SessionManager.UserWrapper.GetLikedPages, this);
            tabLikedPages.Controls.Add(m_PagesGrid.Grid);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
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
            SessionManager.Login();
            if (SessionManager.LoginResult != null)
            {
                adjustUiToLoggedInUser();
            }
        }

        private void adjustUiToLoggedInUser()
        {
            if (SessionManager.AccessToken != null)
            {
                pictureBoxProfile.ImageLocation = SessionManager.User.PictureNormalURL;
                labelName.Text = SessionManager.User.Name;
                labelBirthdate.Text = SessionManager.User.Birthday;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                initTabs();
            }
            else
            {
                SessionManager.LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout();
            clearMainTab(); 
            clearTabs();
            SessionManager.logout();
        }

        private void clearTabs()
        {
            m_AlbumsGrid.Clear();
            m_FriendsGrid.Clear();
            m_PagesGrid.Clear();
            tabLikedPages.Controls.Clear();
            tabAlbums.Controls.Clear();
            tabFriends.Controls.Remove(m_FriendsGrid.Grid);
        }

        private void clearMainTab()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.Image = null;
            labelName.Text = "";
            labelBirthdate.Text = "";
        }


        // If the user has finished resizing the window, resize the selected tab accordingly.
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabAlbums)
            {
                m_AlbumsGrid.adjustGridToForm();
            }
            else if (tabControl.SelectedTab == tabFriends)
            {
                m_FriendsGrid.adjustGridToForm();
            }
            else if (tabControl.SelectedTab == tabLikedPages)
            {
                m_PagesGrid.adjustGridToForm();
            }
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

            foreach (Post timelinePost in SessionManager.User.NewsFeed)
            {
                if(timelinePost.Message != null)
                {
                    listBoxTimeline.Items.Add(timelinePost.Message);
                }
                else if(timelinePost.Caption != null)
                {
                    listBoxTimeline.Items.Add(timelinePost.Caption);
                }
                else
                {
                    listBoxTimeline.Items.Add(string.Format("[{0}]", timelinePost.Type.ToString().ToUpper()));
                }
            }
            if (listBoxTimeline.Items.Count == 0)
            {
                MessageBox.Show("The timeline is up to date.");
            }

        }

        private void listBoxTimeline_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selected = SessionManager.User.Posts[listBoxTimeline.SelectedIndex];
            listBoxComments.DisplayMember = "Message";
            listBoxComments.DataSource = selected.Comments;
        }

        // If no one is selected then returns the user back to the main tab.
        // Otherwise makes each tab execute it's command accordingly.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTabsDisbaled())
            {
                tabControl.SelectedTab = tabPageMain;
            }
            else if (tabControl.SelectedTab == tabAlbums)
            {
                m_AlbumsGrid.adjustGridToForm();
            }
            else if (tabControl.SelectedTab == tabFriends)
            {
                m_FriendsGrid.adjustGridToForm();
            }
            else if (tabControl.SelectedTab == tabLikedPages)
            {
                m_PagesGrid.adjustGridToForm();
            }
        }

        // A check on if other tabs other than the main tab are not enabled.
        // Should happen only in the situations described in the returned value.
        private bool isTabsDisbaled()
        {
            return SessionManager == null || !SessionManager.isLoggedIn();
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

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterMenu filterMenu = new FilterMenu(SessionManager.User);
            DialogResult filterResult = filterMenu.ShowDialog();

            if (filterResult == DialogResult.OK)
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid<User>(filterMenu.FilteredFriendsCollection, this);
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                m_FriendsGrid.adjustGridToForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_FriendsGrid.isDisplayingStaticData())
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid<User>(SessionManager.UserWrapper.GetFriends, this);
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                m_FriendsGrid.adjustGridToForm();
            }
        }
    }
}
