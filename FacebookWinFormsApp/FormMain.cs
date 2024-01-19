using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.session;
using BasicFacebookFeatures.logic.grid;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private int previousNumberOfAlbums;
        public SessionManager SessionManager { get; set; }
        private FacebookObjectDisplayGrid<Album> m_AlbumsGrid;
        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            previousNumberOfAlbums = 0;
        }

        private void initTabs()
        {
            m_AlbumsGrid = new FacebookObjectDisplayGrid<Album>(SessionManager.UserWrapper.GetAlbums, this);
            tabPageAlbums.Controls.Add(m_AlbumsGrid.Grid);
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
            if (SessionManager.AccessToken != null)
            {
                pictureBoxProfile.ImageLocation = SessionManager.User.PictureNormalURL;
                labelName.Text = SessionManager.User.Name;
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
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            SessionManager = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.Image = null;
            labelName.Text = "-";
            m_AlbumsGrid.Clear();
        }


        // If the user has finished resizing the window, resize the selected tab accordingly.
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageAlbums)
            {
                m_AlbumsGrid.adjustGridToForm();
            }
        }

        // If no one is selected then returns the user back to the main tab.
        // Otherwise makes each tab execute it's command accordingly.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTabsDisbaled())
            {
                tabControl1.SelectedTab = tabPageMain;
            }
            else if (tabControl1.SelectedTab == tabPageAlbums)
            {
                m_AlbumsGrid.adjustGridToForm();
            }
        }

        // A check on if other tabs other than the main tab are not enabled.
        // Should happen only in the situations described in the returned value.
        private bool isTabsDisbaled()
        {
            return SessionManager == null || !SessionManager.isLoggedIn();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void AlbumGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
