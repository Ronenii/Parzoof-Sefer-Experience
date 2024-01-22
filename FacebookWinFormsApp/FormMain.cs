using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public SessionManager CurrentSessionManager { get; set; }
        public AppSettings AppSettings { get; set; }
        private FacebookObjectDisplayGrid<Album> m_AlbumsGrid;
        private FacebookObjectDisplayGrid<User> m_FriendsGrid;
        private FacebookObjectDisplayGrid<Page> m_PagesGrid;
        private UserWrapper Wrapper { get; set; }
        private int m_PreviousNumberOfAlbums;
        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
            tableLayoutPanelAutoStatus.Enabled = false;
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            CurrentSessionManager = new SessionManager();
        }

        protected override void OnShown(EventArgs e)
        {
            AppSettings = AppSettings.LoadFromFile();
            if(AppSettings.RememberUser && !string.IsNullOrEmpty(AppSettings.LastAccessToken))
            {
                CurrentSessionManager.LoginFromAppSettings(AppSettings.LastAccessToken);
                checkBoxRemember.Checked = true;
                Wrapper = new UserWrapper(CurrentSessionManager.User);
                adjustUiToLoggedInUser();
            }

            m_PreviousNumberOfAlbums = 0;
        }

        private void initTabs()
        {
            m_AlbumsGrid = new FacebookObjectDisplayGrid<Album>(Wrapper.GetAlbums);
            tabAlbums.Controls.Add(m_AlbumsGrid.Grid);

            m_FriendsGrid = new FacebookObjectDisplayGrid<User>(Wrapper.GetFriends);
            tabFriends.Controls.Add(m_FriendsGrid.Grid);

            m_PagesGrid = new FacebookObjectDisplayGrid<Page>(Wrapper.GetLikedPages);
            tabLikedPages.Controls.Add(m_PagesGrid.Grid);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            AppSettings.RememberUser = this.checkBoxRemember.Checked;
            if(AppSettings.RememberUser)
            {
                AppSettings.LastAccessToken = CurrentSessionManager.AccessToken;
            }

            AppSettings.SaveToFile();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            CurrentSessionManager.Login();
            if (CurrentSessionManager.LoginResult != null)
            {
                Wrapper = new UserWrapper(CurrentSessionManager.User);
                adjustUiToLoggedInUser();
            }
        }

        private void adjustUiToLoggedInUser()
        {
            if (CurrentSessionManager.AccessToken != null)
            {
                pictureBoxProfile.ImageLocation = CurrentSessionManager.User.PictureNormalURL;
                labelName.Text = CurrentSessionManager.User.Name;
                labelBirthdate.Text = CurrentSessionManager.User.Birthday;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                tableLayoutPanelAutoStatus.Enabled = true;
                enableMainTab();
                initTabs();
            }
            else
            {
                disableMainTab();
                CurrentSessionManager.LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            tableLayoutPanelAutoStatus.Enabled = false;
            FacebookService.Logout();
            clearMainTab(); 
            clearTabs();
            CurrentSessionManager.logout();
            Wrapper = null;
            disableMainTab();
        }

        private void disableMainTab()
        {
            textBoxStatus.Enabled = false;
            listBoxComments.Enabled = false;
            listBoxTimeline.Enabled = false;
            buttonPost.Enabled = false;
            linkTimeline.Enabled = false;
        }

        private void enableMainTab()
        {
            textBoxStatus.Enabled = true;
            listBoxComments.Enabled = true;
            listBoxTimeline.Enabled = true;
            buttonPost.Enabled = true;
            linkTimeline.Enabled = true;
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
            listBoxComments.Items.Clear();
            listBoxTimeline.Items.Clear();
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

            foreach (Post timelinePost in CurrentSessionManager.User.NewsFeed)
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
            Post selected = CurrentSessionManager.User.Posts[listBoxTimeline.SelectedIndex];

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
            return CurrentSessionManager == null || !CurrentSessionManager.isLoggedIn();
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
                    postStatus(textBoxStatus.Text);
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
            FilterMenu filterMenu = new FilterMenu(CurrentSessionManager.User);
            DialogResult filterResult = filterMenu.ShowDialog();

            if (filterResult == DialogResult.OK)
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid<User>(filterMenu.FilteredFriendsCollection);
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                m_FriendsGrid.adjustGridToForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_FriendsGrid.isDisplayingStaticData())
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid<User>(Wrapper.GetFriends);
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                m_FriendsGrid.adjustGridToForm();
            }
        }

        private void btnAutoCompliment_Click(object sender, EventArgs e)
        {
            User user = CurrentSessionManager.User;
            Random rand = new Random();
            List<string> compliments = new List<string>
                                           {
                                               "smells like chihuahua!!!!",
                                               "looks like a very pleasant being!",
                                               "has the right amount of nostrils!",
                                               "is very interesting!",
                                               "is smart like GuyRo"
                                           };

            int friendIndex = rand.Next(user.Friends.Count);
            int complimentIndex = rand.Next(compliments.Count);

            postStatus($"{UserWrapper.GetFullName(user.Friends[friendIndex])} {compliments[complimentIndex]}");
        }

        private void postStatus(string i_Status)
        {
            try
            {
                CurrentSessionManager.User.PostStatus(i_Status);
                MessageBox.Show("Status posted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAutoFavoritePages_Click(object sender, EventArgs e)
        {
            User user = CurrentSessionManager.User;
            List<Page> pagesToDiscuss = getRandomPages();
            StringBuilder status = new StringBuilder("Hey everyone! You should check out These pages: ");

            if (user.LikedPages.Count == 0)
            {
                MessageBox.Show("You don't have any pages to talk about...", "You have no hobbies",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < pagesToDiscuss.Count; i++)
            {
                status.Append(pagesToDiscuss[i].Name);
                if (i < pagesToDiscuss.Count - 1)
                {
                    status.Append(", ");
                }
                else
                {
                    status.Append(". ");
                }
            }

            status.Append("I liked these pages and I hope you will too :)");
            postStatus(status.ToString());
        }

        // Shuffle pages list using Fisher-Yates shuffle algorithm and returns a set amount of pages
        private List<Page> getRandomPages()
        {
            int numberOfPagesToDiscuss = 3;
            FacebookObjectCollection<Page> pages = CurrentSessionManager.User.LikedPages;
            Random random = new Random();
            List<Page> res = null;

            for (int i = pages.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Page temp = pages[i];
                pages[i] = pages[j];
                pages[j] = temp;
            }

            if (pages.Count < numberOfPagesToDiscuss)
            {
                res = pages.Take(pages.Count).ToList();
            }
            else
            {
                res = pages.Take(numberOfPagesToDiscuss).ToList();
            }

            return res;
        }

        private void btnAutoShoutoutAlbum_Click(object sender, EventArgs e)
        {
            User user = CurrentSessionManager.User;
            Random rand = new Random();
            int albumIndex = rand.Next(user.Albums.Count);
            Album album = user.Albums[albumIndex];

            postStatus($"Hey everyone! You should checkout my album {user.Albums[albumIndex].Name}! Here's the link {album.Link}.");
        }
    }
}
