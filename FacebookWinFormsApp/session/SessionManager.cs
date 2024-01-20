using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.session
{
    public class SessionManager
    {
        public LoginResult LoginResult { get; set; }
        public User User { get; }
        public String AccessToken { get; }
        public UserWrapper UserWrapper { get; }
        public SessionManager()
        {
            LoginResult = login();
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;
            UserWrapper = new UserWrapper(User);
        }

        private FacebookWrapper.LoginResult login()
        {
            FacebookWrapper.LoginResult loginResult = FacebookService.Login("392372086520900",
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

            return loginResult;
        }

        public bool isLoggedIn()
        {
            return AccessToken != null;
        }
    }
}
