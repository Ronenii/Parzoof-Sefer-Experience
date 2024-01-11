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
        public User User { get{
                if(; };

        public SessionManager()
        {
            
        }

        public FacebookWrapper.LoginResult login()
        {
            FacebookWrapper.LoginResult loginResult = FacebookService.Login("392372086520900",
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

            return loginResult;
        }
    }
}
