using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.session
{
    public static class SessionManager
    {
        public static LoginResult LoginResult { get; set; }
        public static User User { get; set; }
        public static string AccessToken { get; set; }
        
        public static void Login()
        {
            LoginResult = FacebookService.Login("392372086520900",
                "email",
                "public_profile",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos");
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;
        }

        public static void LoginFromAppSettings(string i_AccessToken)
        {
            LoginResult = FacebookService.Connect(i_AccessToken);
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;
        }

        public static bool IsLoggedIn()
        {
            return AccessToken != null;
        }

        public static void Logout()
        {
            User = null;
            AccessToken = null;
            LoginResult = null;
        }
    }
}
