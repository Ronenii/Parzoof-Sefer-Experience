using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public enum e_Gender
    {
        Male,
        Female
    }

    public class GenderFilter : IFilterType  
    {
        private readonly e_Gender r_Gender;

        public GenderFilter(e_Gender i_Gender)
        {
            r_Gender = i_Gender;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            foreach (User user in i_FriendsList)
            {
                if(user.Gender.ToString() != r_Gender.ToString().ToLower())
                {
                    friendsToRemove.Add(user);
                }
            }

            return friendsToRemove;
        }
    }
}
