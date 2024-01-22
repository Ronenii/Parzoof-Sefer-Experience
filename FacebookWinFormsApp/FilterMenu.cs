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
        private readonly User r_User;
        public FacebookObjectCollection<User> FilteredFriendsCollection { get; }
        
        private Dictionary<string, string> m_HometownDictionary;
        public FilterMenu(User i_User)
        {
            InitializeComponent();
            r_User = i_User;
            populateCBoxFriendOf();
            populateCBoxHometown();
        }

        private void populateCBoxFriendOf()
        {
            List<KeyValuePair<string, string>> friendsList = new List<KeyValuePair<string, string>>();
            
            foreach (User friend in r_User.Friends)
            {
                friendsList.Add(new KeyValuePair<string, string>(friend.Id,
                    friend.MiddleName != String.Empty
                        ? $"{friend.FirstName} {friend.MiddleName} {friend.LastName}"
                        : $"{friend.FirstName} {friend.LastName}"));
            }

            foreach (KeyValuePair<string,string> kvp in friendsList)
            {
                cBoxFriendOf.Items.Add(kvp);
            }
            cBoxFriendOf.DataSource = friendsList;
            cBoxFriendOf.DisplayMember = "value";
            cBoxFriendOf.ValueMember = "key";
        }

        private void populateCBoxHometown()
        {
            HashSet<string> homeTownSet = new HashSet<string>();
            foreach (User friend in r_User.Friends)
            {
                if (friend.Hometown != null)
                {
                    homeTownSet.Add(friend.Hometown.Name);
                }
            }

            foreach (string hometown in homeTownSet)
            {
                cBoxFriendOf.Items.Add(hometown);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            
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
