using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class HometownFilter : IFilterType
    {
        private readonly City m_City;

        public HometownFilter(City i_City)
        {
            m_City = i_City;
        }

        public void Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            foreach (User user in i_FriendsList)
            {
                if (user.Location != m_City)
                {
                    i_FriendsList.Remove(user);
                }
            }
        }
    }
}
