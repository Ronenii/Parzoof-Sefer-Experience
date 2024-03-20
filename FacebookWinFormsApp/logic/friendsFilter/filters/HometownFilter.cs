using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class HometownFilter : IFilterStrategy
    {
        private readonly string r_CityName;
        public HometownFilter(string i_CityName)
        {
            r_CityName = i_CityName;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            foreach (User user in i_FriendsList)
            {
                if (user.Location.Name != r_CityName)
                {
                    friendsToRemove.Add(user);
                }
            }

            return friendsToRemove;
        }
    }
}
