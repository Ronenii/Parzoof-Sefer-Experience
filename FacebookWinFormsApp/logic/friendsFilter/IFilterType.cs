using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.logic.friendsFilter
{
    public interface IFilterType
    {
        void Invoke(FacebookObjectCollection<User> i_FriendsList);
    }
}
