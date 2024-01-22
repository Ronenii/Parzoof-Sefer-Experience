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
        private readonly string m_CityName;

        public HometownFilter(string i_CityName)
        {
            m_CityName = i_CityName;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            foreach (User user in i_FriendsList)
            {
                if (user.Location.Name != m_CityName)
                {
                    friendsToRemove.Add(user);
                }
            }

            return friendsToRemove;
        }
    }
}
