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
        private List<IFilterType> m_ChoosenFilters;

        public FriendsFilter(User i_MainUser)
        {
            m_MainUser = i_MainUser;
            m_ChoosenFilters = new List<IFilterType>();
        }

        public void PullUserFriendsList()
        {
            m_UsersFriendsList = new FacebookObjectCollection<User>();
            // Duplicate the friends list.
            foreach(User user in m_MainUser.Friends)
            {
                m_UsersFriendsList.Add(user);
            }
        }

        public void AddFilters(List<IFilterType> i_Filters)
        {
            m_ChoosenFilters = i_Filters;
        }


        public FacebookObjectCollection<User> InvokeFilters()
        {
            FacebookObjectCollection<User> friendsToRemove;

            foreach (IFilterType filter in m_ChoosenFilters)
            {
               friendsToRemove = filter.Invoke(m_UsersFriendsList);
               removeFriends(friendsToRemove);
            }
            
            return m_UsersFriendsList;
        }

        private void removeFriends(FacebookObjectCollection<User> i_FriendsToRemove)
        {
            foreach(User user in i_FriendsToRemove)
            {
                m_UsersFriendsList.Remove(user);
            }
        }
    }
}
