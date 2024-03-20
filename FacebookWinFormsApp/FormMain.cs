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
using System.Threading;
using BasicFacebookFeatures.logic.user.adapter;
using BasicFacebookFeatures.logic.user.wrapper;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public AppSettings AppSettings { get; set; }
        private FacebookObjectDisplayGrid m_AlbumsGrid;
        private FacebookObjectDisplayGrid m_FriendsGrid;
        private FacebookObjectDisplayGrid m_PagesGrid;
        private IUserAdapter m_UserAdapter = new UserAdapter();

        private Thread m_UpdateingThread;
        private readonly object r_UpdateMainTabContext = new object();

        private string m_prevFirstName;
        private string m_prevLastName;
        private string m_prevReligion;
        private DateTime m_prevBDay;
        private bool m_IsEditing = false;

        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
            tableLayoutPanelAutoStatus.Enabled = false;
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            
        }

        protected override void OnShown(EventArgs e)
        {
            AppSettings = AppSettings.LoadFromFile();
            if (AppSettings.RememberUser && !string.IsNullOrEmpty(AppSettings.LastAccessToken))
            {
                SessionManager.LoginFromAppSettings(AppSettings.LastAccessToken);
                checkBoxRemember.Checked = true;
                adjustUiToLoggedInUser();
            }
            else
            {
                disableMainTab();
            }
        }

        private void initTabs()
        {
            m_AlbumsGrid = new FacebookObjectDisplayGrid(m_UserAdapter.GetAlbums);
            tabAlbums.Controls.Add(m_AlbumsGrid.Grid);

            m_FriendsGrid = new FacebookObjectDisplayGrid(m_UserAdapter.GetFriends);
            tabFriends.Controls.Add(m_FriendsGrid.Grid);

            m_PagesGrid = new FacebookObjectDisplayGrid(m_UserAdapter.GetLikedPages);
            tabLikedPages.Controls.Add(m_PagesGrid.Grid);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            AppSettings.RememberUser = this.checkBoxRemember.Checked;
            if (AppSettings.RememberUser)
            {
                AppSettings.LastAccessToken = SessionManager.AccessToken;
            }

            AppSettings.SaveToFile();
            m_UpdateingThread.Abort();
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
                userBindingSource.DataSource = SessionManager.User;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                buttonEdit.Visible = true;
                tableLayoutPanelAutoStatus.Enabled = true;
                enableMainTab();
                initTabs();
                m_UpdateingThread = new Thread(updateMainTabEveryInterval);
                m_UpdateingThread.Start();
            }
            else
            {
                disableMainTab();
                SessionManager.LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_UpdateingThread.Abort();
            tableLayoutPanelAutoStatus.Enabled = false;
            FacebookService.Logout();
            clearMainTab();
            clearTabs();
            SessionManager.Logout();
            disableMainTab();
            buttonEdit.Visible = false;
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
            listBoxComments.DataSource = null;
            listBoxTimeline.Items.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            religionTextBox.Clear();
            birthdayDateTimePicker.ResetText();
            imageSquarePictureBox.Image = null;
        }

        // If the user has finished resizing the window, resize the selected tab accordingly.
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            updateSelectedTab();
        }

        private void linkTimeline_MouseClick(object sender, MouseEventArgs e)
        {
            listBoxTimeline.Invoke(new Action(() =>fetchTimeline()));
        }

        private void fetchTimeline()
        {
            if (listBoxTimeline.Items.Count != 0)
            {
                listBoxTimeline.Items.Clear();
            }
            foreach (Post timelinePost in SessionManager.User.NewsFeed)
            {
                if (timelinePost.Message != null)
                {
                    listBoxTimeline.Items.Add(timelinePost.Message);
                }
                else if (timelinePost.Caption != null)
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
            getPostComments();
        }

        private void getPostComments()
        {
            if(listBoxComments.Items.Count != 0)
            {
                listBoxComments.Items.Clear();
            }

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
            updateSelectedTab();
        }

        private void updateSelectedTab()
        {
            if(tabControl.SelectedTab == tabPageMain && SessionManager.IsLoggedIn())
            {
                new Thread(updateMainTab).Start();
            }
            else if (tabControl.SelectedTab == tabAlbums)
            {
                new Thread(m_AlbumsGrid.PopulateGridWithPanels).Start();
            }
            else if (tabControl.SelectedTab == tabFriends)
            {
                new Thread(m_FriendsGrid.PopulateGridWithPanels).Start();
            }
            else if (tabControl.SelectedTab == tabLikedPages)
            {
                m_PagesGrid.Clear();
                new Thread(m_PagesGrid.PopulateGridWithPanels).Start();
            }
        }

        private void updateMainTabEveryInterval()
        {
            int updateIntervalInMilliseconds = 5000;
            while (SessionManager.IsLoggedIn())
            {
                updateMainTab();
                Thread.Sleep(updateIntervalInMilliseconds);
            }
        }

        private void updateMainTab()
        {
            tabPageMain.Invoke(new Action(() =>
            {
                if (tabControl.SelectedTab == tabPageMain)
                {
                    lock (r_UpdateMainTabContext)
                    {
                        int prevSelectedInTimelineIndex = listBoxTimeline.SelectedIndex;
                        fetchTimeline();
                        if (listBoxComments.SelectedItem != null)
                        {
                            getPostComments();
                        }
                        selectPreviouslySelectedInTimeline(prevSelectedInTimelineIndex);
                    }
                }
            }
            ));
          
        }

        private void selectPreviouslySelectedInTimeline(int i_PrevSelected)
        {
            if(i_PrevSelected < listBoxTimeline.Items.Count)
            {
                listBoxTimeline.SelectedIndex = i_PrevSelected;
            }
        }

        // A check on if other tabs other than the main tab are not enabled.
        // Should happen only in the situations described in the returned value.
        private bool isTabsDisbaled()
        {
            return !SessionManager.IsLoggedIn();
        }

        private void buttonPost_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStatus.Text))
            {
                MessageBox.Show("Please enter a status");
            }
            else
            {
                postStatus(textBoxStatus.Text);
                textBoxStatus.Text = "";
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            FormFilterMenu filterMenu = new FormFilterMenu(SessionManager.User);
            DialogResult filterResult = filterMenu.ShowDialog();

            if (filterResult == DialogResult.OK)
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid(m_UserAdapter.ConvertFilteredFriendsCollection(filterMenu.FilteredFriendsCollection));
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                new Thread(m_FriendsGrid.PopulateGridWithPanels).Start();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (m_FriendsGrid.IsDisplayingStaticData())
            {
                tabFriends.Controls.Remove(m_FriendsGrid.Grid);
                m_FriendsGrid = new FacebookObjectDisplayGrid(m_UserAdapter.GetFriends);
                tabFriends.Controls.Add(m_FriendsGrid.Grid);
                new Thread(m_FriendsGrid.PopulateGridWithPanels).Start();
            }
        }

        private void btnAutoCompliment_Click(object sender, EventArgs e)
        {
            User user = SessionManager.User;
            Random rand = new Random();
            List<string> compliments = new List<string>
                                           {
                                               "smells like chihuahua!!!!",
                                               "looks like a very pleasant being!",
                                               "has the right amount of nostrils!",
                                               "is very interesting!",
                                               "is smart like GuyRo"
                                           };

            if(user.Friends.Count == 0)
            {
                MessageBox.Show(
                    "You don't have friends to compliment. Go visit \"Gan Sha'ashuim\" and make some friends.");
            }
            else
            {
                int friendIndex = rand.Next(user.Friends.Count);
                int complimentIndex = rand.Next(compliments.Count);
                postStatus($"{UserWrapper.GetFullName(user.Friends[friendIndex])} {compliments[complimentIndex]}");
            }
        }

        private void postStatus(string i_Status)
        {
            try
            {
               SessionManager.User.PostStatus(i_Status);
                MessageBox.Show("Status posted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tried to post: \"{i_Status}\". Encountered exeption: \"{ex.Message}");
            }
        }

        private void btnAutoFavoritePages_Click(object sender, EventArgs e)
        {
            User user = SessionManager.User;
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
            FacebookObjectCollection<Page> pages = SessionManager.User.LikedPages;
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
            User user = SessionManager.User;
            Random rand = new Random();
            int albumIndex = rand.Next(user.Albums.Count);
            Album album = user.Albums[albumIndex];

            postStatus($"Hey everyone! You should checkout my album {user.Albums[albumIndex].Name}! Here's the link {album.Link}.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!m_IsEditing)
            {
                enterEditingMode();
            }
            else
            {
                exitEditingMode();
            }

            m_prevBDay = birthdayDateTimePicker.Value;
            m_prevFirstName = firstNameTextBox.Text;
            m_prevLastName = lastNameTextBox.Text;
            m_prevReligion = religionTextBox.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            birthdayDateTimePicker.Value = m_prevBDay;
            firstNameTextBox.Text = m_prevFirstName;
            lastNameTextBox.Text = m_prevLastName;
            religionTextBox.Text = m_prevReligion;
            exitEditingMode();
        }

        private void enterEditingMode()
        {
            m_IsEditing = true;
            buttonCancel.Visible = true;
            panelUserDetails.Enabled = true;
            buttonEdit.Text = "Save";
        }

        private void exitEditingMode()
        {
            buttonCancel.Visible = false;
            buttonEdit.Text = "Edit";
            panelUserDetails.Enabled = false;
            m_IsEditing = false;
        }
    }
}
