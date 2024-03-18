using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.user.adapter
{
    public interface IUserAdapter
    {
        FacebookObjectCollection<FacebookObject> GetAlbums();
        FacebookObjectCollection<FacebookObject> GetFriends();
        FacebookObjectCollection<FacebookObject> GetLikedPages();
        FacebookObjectCollection<FacebookObject> ConvertFilteredFriendsCollection(FacebookObjectCollection<User> i_FilteredFriends);
    }
}
