using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public enum e_Gender
    {
        Male,
        Female
    }

    public class GenderFilter : IFilterType  
    {
        private readonly e_Gender m_Gender;

        public GenderFilter(e_Gender i_Gender)
        {
            m_Gender = i_Gender;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            foreach (User user in i_FriendsList)
            {
                if(user.Gender.ToString() != m_Gender.ToString().ToLower())
                {
                    friendsToRemove.Add(user);
                }
            }

            return friendsToRemove;
        }
    }
}
