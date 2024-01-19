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
        private int m_PreviousObjectCount;
        private TableLayoutPanel m_Grid;
        private FacebookObjectCollection<T> m_FacebookObjectCollection;

        public delegate FacebookObjectCollection<T> GetObjectCollection();


        public FacebookObjectDisplayGrid(GetObjectCollection i_Method)
        {
            this.getObjectCollection = i_Method;
            m_PreviousObjectCount = 0;
            m_Grid = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill
            };
        }

        private GetObjectCollection getObjectCollection;

        public void Clear()
        {
            m_PreviousObjectCount = 0;
            m_Grid.Controls.Clear();
        }

        private void adjustGridToForm(Form i_Form)
        {
            m_FacebookObjectCollection = getObjectCollection();
            int availableWidth = m_Grid.Width - m_Grid.Margin.Horizontal;
            const int pictureBoxWidth = 200;
            int maxColumns = availableWidth / pictureBoxWidth;

            int rows = (int)Math.Ceiling((double)m_FacebookObjectCollection.Count / maxColumns);
            int columns = Math.Min(maxColumns, m_FacebookObjectCollection.Count);

            m_Grid.RowCount = rows;
            m_Grid.ColumnCount = columns;

            m_Grid.SuspendLayout();
            addObjectsToGrid(columns);
            m_Grid.ResumeLayout();
        }

        // Re-create the object grid if nany object were added or deleted.
        private void addObjectsToGrid(int i_Columns)
        {

            if (m_FacebookObjectCollection.Count != m_PreviousObjectCount)
            {
                m_Grid.Controls.Clear();

                for (int i = 0; i < m_FacebookObjectCollection.Count; i++)
                {
                    int row = i / i_Columns;
                    int col = i % i_Columns;
                    int objectIndex = (row + 1) * (col + 1) - 1;

                    m_Grid.Controls.Add(createNewAlbumDisplayPanel(m_FacebookObjectCollection[objectIndex]), col, row);
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
