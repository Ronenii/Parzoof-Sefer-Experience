﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public class AgeFilter : IFilterType
    {
        private readonly int m_From;
        private readonly int m_To;

        public AgeFilter(int i_From, int i_To)
        {
            m_From = i_From;
            m_To = i_To;
        }

        public void Invoke(FacebookObjectCollection<User> i_FriendsList)
        {
            int userAge;

            foreach(User user in i_FriendsList)
            {
                userAge = ageCalculator(user.Birthday);
                if(userAge < m_From || userAge > m_To)
                {
                    i_FriendsList.Remove(user);
                }
            }
        }

        private int ageCalculator(string i_Birthday)
        {
            DateTime birthDate = DateTime.ParseExact(i_Birthday, "yyyy-MM-dd", null);
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
