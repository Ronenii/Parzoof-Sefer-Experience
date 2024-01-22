using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class FriendsOfFilter : IFilterType
    {
        private readonly User m_Friend;

        public FriendsOfFilter(User i_Friend)
        {
            m_Friend = i_Friend;
        }

        public void Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            if(m_Friend != null)
            {
                foreach (User user in i_FriendsList)
                {
                    if (!m_Friend.Friends.Contains(user))
                    {
                        i_FriendsList.Remove(user);
                    }
                }
            }
        }
    }
}
