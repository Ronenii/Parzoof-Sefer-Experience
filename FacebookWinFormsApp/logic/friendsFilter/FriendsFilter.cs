using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter
{
    public class FriendsFilter
    {
        private readonly User m_MainUser;
        private FacebookObjectCollection<User> m_UsersFriendsList;
        private Dictionary<string, IFilterType> m_ChoosenFilters;

        public FriendsFilter(User i_MainUser)
        {
            m_MainUser = i_MainUser;
            m_ChoosenFilters = new Dictionary<string, IFilterType>();
            m_UsersFriendsList = m_MainUser.Friends;
        }

        private void pullUserFriendsList()
        {
            m_UsersFriendsList = m_MainUser.Friends;
        }

        public void AddFilter(string i_Key, IFilterType i_Filter)
        {
            m_ChoosenFilters.Add(i_Key, i_Filter);
        }

        public void DeleteFilter(string i_Key)
        {
            m_ChoosenFilters.Remove(i_Key);
        }

        public FacebookObjectCollection<User> InvokeFilters()
        {
            if(m_ChoosenFilters.Count == 0)
            {
                pullUserFriendsList();
            }
            else
            {
                foreach (IFilterType filter in m_ChoosenFilters.Values)
                {
                    filter.Invoke(m_UsersFriendsList);
                }
            }

            return m_UsersFriendsList;
        }
    }
}
