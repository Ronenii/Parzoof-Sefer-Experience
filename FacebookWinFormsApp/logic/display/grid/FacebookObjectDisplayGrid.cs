﻿using BasicFacebookFeatures.logic.display.obj;
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
        private FacebookObjectCollection<T> m_FacebookObjectCollectionToDisplay;
        private FacebookObjectCollection<T> m_PreviousFacebookObjectCollectionToDisplay;
        public TableLayoutPanel Grid { get; }

        private readonly object r_AddObjectContext = new object();


        // This class requires the appropriate getter for the Object
        public FacebookObjectDisplayGrid(GetObjectCollectionDelegate i_UserDataGetterMethod)
        {
            r_IsDisplayingStaticData = false;
            this.getObjectCollectionDelegate = i_UserDataGetterMethod;
            //m_PreviousObjectCount = 0;
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
            m_FacebookObjectCollectionToDisplay = i_FacebookObjectCollection;
            r_IsDisplayingStaticData = true;
            //m_PreviousObjectCount = 0;
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
            return r_IsDisplayingStaticData;
        }

        public void Clear()
        {
            //m_PreviousObjectCount = 0;
            Grid.Invoke(new Action(()=>Grid.Controls.Clear()));
        }

        public void InvokePopulateGridWithPanels()
        {
            Grid.Invoke(new Action(() => PopulateGridWithPanels()));
        }

        // Adjusts album grid according to the form's size, adds FacebookObjects to grid if needed.
        private void PopulateGridWithPanels()
        {
            m_FacebookObjectCollectionToDisplay = getObjectCollectionDelegate();

            int availableWidth = Grid.Width - Grid.Margin.Horizontal;
            const int pictureBoxWidth = 200;
            int maxColumns = availableWidth / pictureBoxWidth;
            int rows = (int)Math.Ceiling((double)m_FacebookObjectCollectionToDisplay.Count / maxColumns);
            int columns = Math.Min(maxColumns, m_FacebookObjectCollectionToDisplay.Count);


            Grid.RowCount = rows;
            Grid.ColumnCount = columns;
            addObjectsToGrid(columns);
            Grid.Refresh();
        }

        // Re-create the object grid if nany object were added or deleted.
        private void addObjectsToGrid(int i_Columns)
        {
            Grid.Controls.Clear();
            for (int i = 0; i < m_FacebookObjectCollectionToDisplay.Count; i++)
            {
                lock (r_AddObjectContext)
                {
                    int row = i / i_Columns;
                    int col = i % i_Columns;
                    int objectIndex = (row + 1) * (col + 1) - 1;

                    Grid.Controls.Add(createNewAlbumDisplayPanel(m_FacebookObjectCollectionToDisplay[objectIndex]), col, row);
                }
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
                Image = displayedFacebookObject.GetImage()
            };
            Size coverSize = new Size(pictureBoxWidth, pictureBoxWidth);

            objectImagePictureBox.Size = coverSize;

            Label objectNameLabel = new Label
            {
                Text = displayedFacebookObject.GetDisplayedText(),
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

        private bool facebookObjectCollectionsEqual()
        {
            bool ret = true;
            if (m_FacebookObjectCollectionToDisplay.Count != m_PreviousFacebookObjectCollectionToDisplay.Count)
            {
                ret = false;
            }
            else
            {
                foreach (T obj in m_FacebookObjectCollectionToDisplay)
                {
                    if (obj is Album)
                    {

                    }
                    else if (obj is User)
                    {

                    }
                    else if (obj is Page)
                    {

                    }
                }
            }

            return ret;
        }
    }
}
