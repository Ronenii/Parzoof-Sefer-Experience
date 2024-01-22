using FacebookWrapper.ObjectModel;

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

        public static string GetFullName(User i_user)
        {
            if (i_user.MiddleName != null)
            {
                return $"{i_user.FirstName} {i_user.MiddleName} {i_user.LastName}";
            }
            return $"{i_user.FirstName} {i_user.LastName}";
        }
    }
}
