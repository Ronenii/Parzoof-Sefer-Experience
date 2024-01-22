using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FilterMenu : Form
    {
        private readonly FacebookObjectCollection<User> r_FriendsCollection;
        public FacebookObjectCollection<User> FilteredFriendsCollection { get; }
        public FilterMenu(FacebookObjectCollection<User> friendsCollection)
        {
            InitializeComponent();
            r_FriendsCollection = friendsCollection;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            rBtnFemale.Checked = false;
        }

        private void rBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            rBtnMale.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            numericUDFrom.Value = 0;
            numericUDTo.Value = 0;
            rBtnFemale.Checked = false;
            rBtnMale.Checked = false;
            cBoxHometown.SelectedItem = null;
            cBoxFriendOf.SelectedItem = null;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (numericUDFrom.Value > numericUDTo.Value)
            {
                MessageBox.Show("Invalid age range", "Age filter error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
