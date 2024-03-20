using System;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class AgeFilter : IFilterStrategy
    {
        private readonly int r_From;
        private readonly int r_To;
        public AgeFilter(int i_From, int i_To)
        {
            r_From = i_From;
            r_To = i_To;
        }

        public FacebookObjectCollection<User> Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            int userAge;
            FacebookObjectCollection<User> friendsToRemove = new FacebookObjectCollection<User>();

            foreach (User user in i_FriendsList)
            {
                userAge = ageCalculator(user.Birthday);
                if(userAge < r_From || userAge > r_To)
                {
                    friendsToRemove.Add(user);
                }
            }

            return friendsToRemove;
        }

        private int ageCalculator(string i_Birthday)
        {
            DateTime birthDate = DateTime.ParseExact(i_Birthday, "MM/dd/yyyy", null);
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;

            // Check if the birthday has occurred this year
            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
