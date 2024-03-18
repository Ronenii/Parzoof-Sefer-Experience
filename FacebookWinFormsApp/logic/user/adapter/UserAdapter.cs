using BasicFacebookFeatures.logic.user.adapter;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.session
{
    public class UserAdapter : IUserAdapter
    {
        public FacebookObjectCollection<FacebookObject> GetAlbums()
        {
            FacebookObjectCollection<Album> albums = SessionManager.User.Albums;

            return convertFacebookObjectCollectionToGenericCollection(albums);
        }

        public FacebookObjectCollection<FacebookObject> GetFriends()
        {
            FacebookObjectCollection<User> friends = SessionManager.User.Friends;

            return convertFacebookObjectCollectionToGenericCollection(friends);
        }

        public FacebookObjectCollection<FacebookObject> GetLikedPages()
        {
            FacebookObjectCollection<Page> likedPages = SessionManager.User.LikedPages;

            return convertFacebookObjectCollectionToGenericCollection(likedPages);
        }

        public FacebookObjectCollection<FacebookObject> ConvertFilteredFriendsCollection(FacebookObjectCollection<User> i_FilteredFriends)
        {
            return convertFacebookObjectCollectionToGenericCollection(i_FilteredFriends);
        }

        private FacebookObjectCollection<FacebookObject> convertFacebookObjectCollectionToGenericCollection<T>(FacebookObjectCollection<T> i_Collection)
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
