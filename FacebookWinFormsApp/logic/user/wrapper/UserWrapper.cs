using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.user.wrapper
{
    public static class UserWrapper
    {
        public static string GetFullName(User i_user)
        {
            string res = null;

            if (i_user.MiddleName != null)
            {
                res = $"{i_user.FirstName} {i_user.MiddleName} {i_user.LastName}";
            }
            else
            {
                res = $"{i_user.FirstName} {i_user.LastName}";
            }

            return res;
        }
    }
}
