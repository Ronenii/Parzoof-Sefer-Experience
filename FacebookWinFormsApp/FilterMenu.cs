using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicFacebookFeatures.logic.friendsFilter;
using BasicFacebookFeatures.logic.friendsFilter.filters;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FilterMenu : Form
    {
        private readonly User r_User;
        public FacebookObjectCollection<User> FilteredFriendsCollection { get; set; }

        private FriendsFilter m_FriendsFilter;

        private Dictionary<string, string> m_HometownDictionary;
        public FilterMenu(User i_User)
        {
            InitializeComponent();
            m_FriendsFilter = new FriendsFilter(i_User);
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
            cBoxFriendOf.SelectedItem = null;
        }

        private void populateCBoxHometown()
        {
            HashSet<string> locationSet = new HashSet<string>();
            foreach (User friend in r_User.Friends)
            {
                if (friend.Location != null)
                {
                    locationSet.Add(friend.Location.Name);
                }
            }

            foreach (string location in locationSet)
            {
                cBoxLocation.Items.Add(location);
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
            cBoxLocation.SelectedItem = null;
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
                addFilters();
                FilteredFriendsCollection = m_FriendsFilter.InvokeFilters();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void addFilters()
        {
            List<IFilterType> addedFilters = new List<IFilterType>();

            addAgeRange(addedFilters);
            addGenders(addedFilters);
            addHometown(addedFilters);
            addFriendsOf(addedFilters);
            m_FriendsFilter.AddFilters(addedFilters);
        }

        private void addAgeRange(List<IFilterType> i_AddedFilters)
        {
            if (numericUDTo.Value != 0)
            {
                AgeFilter ageFilter = new AgeFilter(int.Parse(numericUDFrom.Text), int.Parse(numericUDTo.Text));
                i_AddedFilters.Add(ageFilter);
            }
        }

        private void addGenders(List<IFilterType> i_AddedFilters)
        {
            if (rBtnMale.Checked)
            {
                GenderFilter genderFilter = new GenderFilter(e_Gender.Male);
                i_AddedFilters.Add(genderFilter);
            }
            else if(rBtnFemale.Checked)
            {
                GenderFilter genderFilter = new GenderFilter(e_Gender.Female);
                i_AddedFilters.Add(genderFilter);
            }
        }

        private void addHometown(List<IFilterType> i_AddedFilters)
        {
            if (cBoxLocation.SelectedItem != null)
            {
                HometownFilter hometownFilter = new HometownFilter(cBoxLocation.SelectedItem.ToString());
                i_AddedFilters.Add(hometownFilter);
            }
        }

        private void addFriendsOf(List<IFilterType> i_AddedFilters)
        {
            if (cBoxFriendOf.SelectedItem != null)
            {
                KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)cBoxFriendOf.SelectedItem;
                User choosenFriend = null;

                foreach(User user in r_User.Friends)
                {
                    if(user.Id == kvp.Key)
                    {
                        choosenFriend = user;
                    }
                }

                FriendsOfFilter friendsOfFilter = new FriendsOfFilter(choosenFriend);
                i_AddedFilters.Add(friendsOfFilter);
            }
        }
    }
}
