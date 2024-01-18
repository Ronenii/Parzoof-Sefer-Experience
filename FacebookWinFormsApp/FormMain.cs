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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private int previousNumberOfAlbums;
        public SessionManager SessionManager { get; set; }
        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            previousNumberOfAlbums = 0;
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
                AlbumGrid.Controls.Clear();
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
            clearAlbums();
        }

        private void clearAlbums()
        {
            AlbumGrid.Controls.Clear();
            previousNumberOfAlbums = 0;
        }

        // Adjusts album grid according to the form's size, adds albums to grid if needed.
        private void AdjustAlbumGrid()
        {
            FacebookObjectCollection<Album> albums = SessionManager.User.Albums;
            int availableWidth = AlbumGrid.Width - AlbumGrid.Margin.Horizontal;
            const int pictureBoxWidth = 200;
            int maxColumns = availableWidth / pictureBoxWidth;

            int rows = (int)Math.Ceiling((double)albums.Count / maxColumns);
            int columns = Math.Min(maxColumns, albums.Count);

            AlbumGrid.RowCount = rows;
            AlbumGrid.ColumnCount = columns;

            AlbumGrid.SuspendLayout();
            addAlbumsToGrid(albums, columns);
            AlbumGrid.ResumeLayout();
        }

        // Re-create the album grid if nany albums were added or deleted.
        private void addAlbumsToGrid(FacebookObjectCollection<Album> i_Albums, int i_Columns)
        {
            
            if (i_Albums.Count != previousNumberOfAlbums)
            {
                AlbumGrid.Controls.Clear();

                for (int i = 0; i < i_Albums.Count; i++)
                {
                    int row = i / i_Columns;
                    int col = i % i_Columns;
                    int albumIndex = (row + 1) * (col + 1) - 1;
                    
                    AlbumGrid.Controls.Add(createNewAlbumDisplayPanel(i_Albums[albumIndex]), col, row);
                }

                previousNumberOfAlbums = i_Albums.Count;
            }
        }

        // Given an album, builds a TableLayoutPanel containing it's name and picture.
        private TableLayoutPanel createNewAlbumDisplayPanel(Album i_Album)
        {
            const int pictureBoxWidth = 200;
            const int maxTextHeight = 100;
            const int elementsInPanel = 2;
            PictureBox albumCoverPictureBox = new PictureBox
            {
                Image = i_Album.ImageAlbum
            };
            Size coverSize = new Size(pictureBoxWidth, pictureBoxWidth);
            albumCoverPictureBox.Size = coverSize;

            Label albumNameLabel = new Label
            {
                Text = i_Album.Name,
                AutoSize = true,
                MaximumSize = new Size(pictureBoxWidth, maxTextHeight),
                Anchor = AnchorStyles.None,
                TextAlign = ContentAlignment.MiddleCenter
            };

            TableLayoutPanel albumDisplayPanel = new TableLayoutPanel
            {
                AutoSize = true,
                RowCount = elementsInPanel,
                ColumnCount = 1
            };
            albumDisplayPanel.Controls.Add(albumCoverPictureBox, 0, 0);
            albumDisplayPanel.Controls.Add(albumNameLabel, 0, 1);

            return albumDisplayPanel;
        }

        // If the user has finished resizing the window, resize the selected tab accordingly.
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageAlbums)
            {
                AdjustAlbumGrid();
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
                AdjustAlbumGrid();
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
