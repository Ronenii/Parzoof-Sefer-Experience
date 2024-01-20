using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class AgeFilter : IFilterType
    {
        private readonly int m_From;
        private readonly int m_To;

        public AgeFilter(int i_From, int i_To)
        {
            m_From = i_From;
            m_To = i_To;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            throw new NotImplementedException();
        }
    }
}
