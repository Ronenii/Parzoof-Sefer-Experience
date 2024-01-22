using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter
{
    public interface IFilterType
    {
        FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList);
    }
}
