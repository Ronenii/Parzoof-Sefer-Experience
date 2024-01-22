using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.session
{
    // gives User class getter functions for properties.
    public class UserWrapper
    {
        private readonly User r_User;

        public UserWrapper(User i_User)
        {
            r_User = i_User;
        }

        public FacebookObjectCollection<Album> GetAlbums()
        {
            return r_User.Albums;
        }

        public FacebookObjectCollection<User> GetFriends()
        {
            return r_User.Friends;
        }

        public FacebookObjectCollection<Page> GetLikedPages()
        {
            return r_User.LikedPages;
        }
    }
}
