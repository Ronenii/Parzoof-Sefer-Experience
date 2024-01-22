using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter
{
    public class FriendsFilter
    {
        private readonly User r_MainUser;
        private FacebookObjectCollection<User> m_UsersFriendsList;
        private List<IFilterType> m_ChoosenFilters;
        public FriendsFilter(User i_MainUser)
        {
            r_MainUser = i_MainUser;
            m_ChoosenFilters = new List<IFilterType>();
        }

        public void PullUserFriendsList()
        {
            m_UsersFriendsList = new FacebookObjectCollection<User>();

            // Duplicate the friends list.
            foreach(User user in r_MainUser.Friends)
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
            
            m_ChoosenFilters.Clear();

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
