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
            m_UsersFriendsList = m_MainUser.Friends;
        }

        private void pullUserFriendsList()
        {
            m_UsersFriendsList = m_MainUser.Friends;
        }

        public void AddFilter(IFilterType i_Filter)
        {
            m_ChoosenFilters.Add(i_Filter);
        }

        public FacebookObjectCollection<User> InvokeFilters()
        {
            foreach(IFilterType filter in m_ChoosenFilters)
            {
                
            }

            return null;
        }


    }
}
