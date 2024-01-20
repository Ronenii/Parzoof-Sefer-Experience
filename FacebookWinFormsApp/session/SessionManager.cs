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
        public String AccessToken { get; set; }

        public void Login()
        {
            LoginResult = FacebookService.Login("392372086520900",
                "email",
                "public_profile",
                "user_birthday",
                "user_friends",
                "user_posts",
                "user_photos",
                "user_likes",
                "user_friends",
                "user_location",
                "user_videos");
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;

        }

        public void LoginFromAppSettings(string i_AccessToken)
        {
            LoginResult = FacebookService.Connect(i_AccessToken);
            User = LoginResult.LoggedInUser;
            AccessToken = LoginResult.AccessToken;
        }
    }
}
