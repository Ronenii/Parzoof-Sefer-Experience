using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter
{
    public interface IFilterStrategy
    {
        FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList);
    }
}
