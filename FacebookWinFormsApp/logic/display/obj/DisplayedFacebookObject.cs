using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.logic.display.obj
{
    class DisplayedFacebookObject<T>
    {
        private class FacebookObjectDisplayData
        {
            private readonly Image r_Image;
            private readonly string r_DisplayedText;
            public FacebookObjectDisplayData(Image i_Image, string i_DisplayedText)
            {
                r_Image = i_Image;
                r_DisplayedText = i_DisplayedText;
            }
            
            public Image GetImage()
            {
                return r_Image;
            }

            public string GetDisplayedText()
            {
                return r_DisplayedText;
            }
        }

        private const string k_NoImageFoundFileName = "No image found.png";
        public readonly string r_NoImageFoundPicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "res", k_NoImageFoundFileName);

        private readonly T r_BaseFacebookObject;
        public readonly Image r_Image;
        public readonly string r_DisplayedText;
        public readonly string r_Id;

        public DisplayedFacebookObject(T i_BaseFacebookObject)
        {
            if(!(i_BaseFacebookObject is FacebookObject))
            {
                throw new ArgumentException("Class DisplayedFacebookObject must get a FacebookObject. ReceivedType: " + i_BaseFacebookObject.GetType().FullName);
            }
            FacebookObjectDisplayData facebookObjectDisplayData= getDisplayDataFromBaseObject(i_BaseFacebookObject);
            r_BaseFacebookObject = i_BaseFacebookObject;
            r_Image = facebookObjectDisplayData.GetImage();
            r_DisplayedText = facebookObjectDisplayData.GetDisplayedText();
            r_Id = (i_BaseFacebookObject as FacebookObject).Id;

        }

        private FacebookObjectDisplayData getDisplayDataFromBaseObject(T i_BaseFacebookObject)
        {
            if (i_BaseFacebookObject is Album)
            {
                Album album = i_BaseFacebookObject as Album;
                return new FacebookObjectDisplayData(album.ImageAlbum,album.Name);
            }
            if(i_BaseFacebookObject is User)
            {
                User user = i_BaseFacebookObject as User;
                string userFullName;
                if (user.MiddleName != null)
                {
                    userFullName = $"{user.FirstName} {user.MiddleName} {user.LastName}";
                }
                else
                {
                    userFullName = $"{user.FirstName} {user.LastName}";
                }
                try
                {
                    return new FacebookObjectDisplayData(user.ImageSquare, $@"{userFullName}
{user.Birthday}
{user.Gender}
{user.Location.Name}");
                }
                catch (WebException e)
                {
                    return new FacebookObjectDisplayData(Image.FromFile(r_NoImageFoundPicturePath), $@"{userFullName}
{user.Birthday}
{user.Gender}
{user.Location.Name}");
                }
            }

            throw new ArgumentException("Unsupported object type for display: " + i_BaseFacebookObject.GetType().FullName);
        }

    }   

}
