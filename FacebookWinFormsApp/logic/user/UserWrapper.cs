using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.session
{
    // gives User class getter functions for properties.
    public static class UserWrapper
    {
        public static FacebookObjectCollection<FacebookObject> GetAlbums()
        {
            FacebookObjectCollection<Album> albums = SessionManager.User.Albums;

            return ConvertFacebookObjectCollectionToGenericCollection(albums);
        }

        public static FacebookObjectCollection<FacebookObject> GetFriends()
        {
            FacebookObjectCollection<User> friends = SessionManager.User.Friends;

            return ConvertFacebookObjectCollectionToGenericCollection(friends);
        }

        public static FacebookObjectCollection<FacebookObject> GetLikedPages()
        {
            FacebookObjectCollection<Page> likedPages = SessionManager.User.LikedPages;

            return ConvertFacebookObjectCollectionToGenericCollection(likedPages);
        }

        public static string GetFullName(User i_user)
        {
            string res = null;

            if (i_user.MiddleName != null)
            {
                res = $"{i_user.FirstName} {i_user.MiddleName} {i_user.LastName}";
            }
            else
            {
                res = $"{i_user.FirstName} {i_user.LastName}";
            }

            return res;
        }

        public static FacebookObjectCollection<FacebookObject> ConvertFacebookObjectCollectionToGenericCollection<T>(FacebookObjectCollection<T> i_Collection)
        {
            FacebookObjectCollection<FacebookObject> ret = new FacebookObjectCollection<FacebookObject>();
            foreach(T facebookObject in i_Collection)
            {
                ret.Add(facebookObject as FacebookObject);
            }

            return ret;
        }
    }
}
