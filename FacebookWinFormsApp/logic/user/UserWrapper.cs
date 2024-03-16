using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.session
{
    // gives User class getter functions for properties.
    public static class UserWrapper
    {
        public static FacebookObjectCollection<Album> GetAlbums()
        {
            Face
            return SessionManager.User.Albums;
        }

        public static FacebookObjectCollection<User> GetFriends()
        {
            return SessionManager.User.Friends;
        }

        public static FacebookObjectCollection<Page> GetLikedPages()
        {
            return SessionManager.User.LikedPages;
        }

        public static string GetFullName(User i_user)
        {
            string res = null;

            if(i_user.MiddleName != null)
            {
                res = $"{i_user.FirstName} {i_user.MiddleName} {i_user.LastName}";
            }
            else
            {
                res = $"{i_user.FirstName} {i_user.LastName}";
            }

            return res;
        }
    }
}
