using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.logic.friendsFilter.filters
{
    public enum e_Gender
    {
        Male,
        Female
    }

    public class GenderFilter
    {
        private readonly e_Gender m_Gender;

        public GenderFilter(e_Gender i_Gender)
        {
            m_Gender = i_Gender;
        }
    }
}
