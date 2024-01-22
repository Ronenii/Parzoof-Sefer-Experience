using BasicFacebookFeatures.logic.display.obj;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures.logic.grid
{
    public class FacebookObjectDisplayGrid<T>
    {
        private FacebookObjectCollection<T> m_FacebookObjectCollection;
        private readonly Form r_Parent;

        private int m_PreviousObjectCount;
        public TableLayoutPanel Grid { get; }
        public delegate FacebookObjectCollection<T> GetObjectCollection();

        private readonly bool r_isDisplayingStaticData;

        // This class requires the appropriate getter for the Object
        public FacebookObjectDisplayGrid(GetObjectCollection i_UserDataGetterMethod, Form i_Parent)
        {
            r_isDisplayingStaticData = false;
            this.getObjectCollection = i_UserDataGetterMethod;
            r_Parent = i_Parent;
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
        public FacebookObjectDisplayGrid(FacebookObjectCollection<T> i_FacebookObjectCollection, Form i_Parent)
        {
            m_FacebookObjectCollection = i_FacebookObjectCollection;
            r_isDisplayingStaticData = true;
            r_Parent = i_Parent;
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

        public bool IsDisplayingStaticData()
        {
            return r_isDisplayingStaticData;
        }

        private GetObjectCollection getObjectCollection;

        public void Clear()
        {
            m_PreviousObjectCount = 0;
            Grid.Controls.Clear();
        }

        // Adjusts album grid according to the form's size, adds FacebookObjects to grid if needed.
        public void adjustGridToForm()
        {
            if (!r_isDisplayingStaticData)
            {
                m_FacebookObjectCollection = getObjectCollection();
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
                    if(m_FacebookObjectCollection[objectIndex]is Album)
                    {

                    }
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
