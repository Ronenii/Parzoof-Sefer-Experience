using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class FriendsOfFilter : IFilterStrategy
    {
        private readonly User r_Friend;
        public FriendsOfFilter(User i_Friend)
        {
            r_Friend = i_Friend;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            if (r_Friend != null)
            {
                foreach (User user in i_FriendsList)
                {
                    if (!isFriend(user))
                    {
                        friendsToRemove.Add(user);
                    }
                }
            }

            return friendsToRemove;
        }

        // This method is necessary because the given user object and the users in
        // "r_Friend.Friends" are not the same objects, they have the same data.
        private bool isFriend(User i_User)
        {
            bool res = false;

            foreach (User user in r_Friend.Friends)
            {
                if (user.Id == i_User.Id)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }
    }
}
