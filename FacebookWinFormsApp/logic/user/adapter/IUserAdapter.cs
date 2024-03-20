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
