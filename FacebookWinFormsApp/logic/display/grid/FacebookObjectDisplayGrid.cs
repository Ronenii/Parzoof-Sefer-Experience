using BasicFacebookFeatures.logic.display.obj;
using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures.logic.grid
{
    public class FacebookObjectDisplayGrid<T>
    {
        public delegate FacebookObjectCollection<T> GetObjectCollectionDelegate();
        private GetObjectCollectionDelegate getObjectCollectionDelegate;

        private readonly bool r_IsDisplayingStaticData;
        private FacebookObjectCollection<T> m_FacebookObjectCollection;
        private int m_PreviousObjectCount;
        public TableLayoutPanel Grid { get; }


        // This class requires the appropriate getter for the Object
        public FacebookObjectDisplayGrid(GetObjectCollectionDelegate i_UserDataGetterMethod)
        {
            r_IsDisplayingStaticData = false;
            this.getObjectCollectionDelegate = i_UserDataGetterMethod;
            m_PreviousObjectCount = 0;
            Grid = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Visible = true,
                Enabled = true,
                AutoScroll = true
            };
        }

        public FacebookObjectDisplayGrid(FacebookObjectCollection<T> i_FacebookObjectCollection)
        {
            m_FacebookObjectCollection = i_FacebookObjectCollection;
            r_IsDisplayingStaticData = true;
            m_PreviousObjectCount = 0;
            Grid = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Visible = true,
                Enabled = true,
                AutoScroll = true
            };
        }

        public bool isDisplayingStaticData()
        {
            return r_IsDisplayingStaticData;
        }

        public void Clear()
        {
            m_PreviousObjectCount = 0;
            Grid.Controls.Clear();
        }

        // Adjusts album grid according to the form's size, adds FacebookObjects to grid if needed.
        public void adjustGridToForm()
        {
            if (!r_IsDisplayingStaticData)
            {
                m_FacebookObjectCollection = getObjectCollectionDelegate();
            }

            int availableWidth = Grid.Width - Grid.Margin.Horizontal;
            const int pictureBoxWidth = 200;
            int maxColumns = availableWidth / pictureBoxWidth;
            int rows = (int)Math.Ceiling((double)m_FacebookObjectCollection.Count / maxColumns);
            int columns = Math.Min(maxColumns, m_FacebookObjectCollection.Count);

            Grid.RowCount = rows;
            Grid.ColumnCount = columns;
            Grid.SuspendLayout();
            addObjectsToGrid(columns);
            Grid.ResumeLayout();
            Grid.Refresh();
        }

        // Re-create the object grid if nany object were added or deleted.
        private void addObjectsToGrid(int i_Columns)
        {
            if (m_FacebookObjectCollection.Count != m_PreviousObjectCount)
            {
                Grid.Controls.Clear();
                for (int i = 0; i < m_FacebookObjectCollection.Count; i++)
                {
                    int row = i / i_Columns;
                    int col = i % i_Columns;
                    int objectIndex = (row + 1) * (col + 1) - 1;

                    Grid.Controls.Add(createNewAlbumDisplayPanel(m_FacebookObjectCollection[objectIndex]), col, row);
                }

                m_PreviousObjectCount = m_FacebookObjectCollection.Count;
            }
        }

        // Given an object, builds a TableLayoutPanel containing the required displayText and picture.
        private TableLayoutPanel createNewAlbumDisplayPanel(T i_FacebookObject)
        {
            DisplayedFacebookObject<T> displayedFacebookObject = new DisplayedFacebookObject<T>(i_FacebookObject);
            const int pictureBoxWidth = 200;
            const int maxTextHeight = 100;
            const int elementsInPanel = 2;
            PictureBox objectImagePictureBox = new PictureBox
            {
                Image = displayedFacebookObject.r_Image
            };
            Size coverSize = new Size(pictureBoxWidth, pictureBoxWidth);

            objectImagePictureBox.Size = coverSize;

            Label objectNameLabel = new Label
            {
                Text = displayedFacebookObject.r_DisplayedText,
                AutoSize = true,
                MaximumSize = new Size(pictureBoxWidth, maxTextHeight),
                Anchor = AnchorStyles.None,
                TextAlign = ContentAlignment.MiddleCenter
            };

            TableLayoutPanel objectDisplayPanel = new TableLayoutPanel
            {
                AutoSize = true,
                RowCount = elementsInPanel,
                ColumnCount = 1
            };

            objectDisplayPanel.Controls.Add(objectImagePictureBox, 0, 0);
            objectDisplayPanel.Controls.Add(objectNameLabel, 0, 1);

            return objectDisplayPanel;
        }
    }
}
