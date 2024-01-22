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
        public User User { get; set; }
        public string AccessToken { get; set; }
        public UserWrapper UserWrapper { get; set; }


        public void Login()
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
            UserWrapper = new UserWrapper(User);
            AccessToken = LoginResult.AccessToken;
        }

        public void LoginFromAppSettings(string i_AccessToken)
        {
            LoginResult = FacebookService.Connect(i_AccessToken);
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;
            UserWrapper = new UserWrapper(User);
            Console.WriteLine(User.Friends);
        }

        public bool isLoggedIn()
        {
            return AccessToken != null;
        }
    }
}
