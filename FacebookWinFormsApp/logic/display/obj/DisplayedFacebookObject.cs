using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BasicFacebookFeatures.session;

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
        private readonly string r_NoImageFoundPicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "res", k_NoImageFoundFileName);
        private readonly Image r_Image;
        private readonly string r_DisplayedText;
        private readonly string r_Id;

        public string GetId()
        {
            return r_Id;
        }
        public Image GetImage()
        {
            return r_Image;
        }
        public string GetDisplayedText()
        {
            return r_DisplayedText;
        }

        public DisplayedFacebookObject(T i_BaseFacebookObject)
        {
            if (!(i_BaseFacebookObject is FacebookObject))
            {
                throw new ArgumentException("Class DisplayedFacebookObject must get a FacebookObject. ReceivedType: " + i_BaseFacebookObject.GetType().FullName);
            }

            FacebookObjectDisplayData facebookObjectDisplayData = getDisplayDataFromBaseObject(i_BaseFacebookObject);
            r_Image = facebookObjectDisplayData.GetImage();
            r_DisplayedText = facebookObjectDisplayData.GetDisplayedText();
            r_Id = (i_BaseFacebookObject as FacebookObject).Id;
        }

        private FacebookObjectDisplayData getDisplayDataFromBaseObject(T i_BaseFacebookObject)
        {
            FacebookObjectDisplayData ret = null;
            if (i_BaseFacebookObject is Album)
            {
                Album album = i_BaseFacebookObject as Album;
                ret = new FacebookObjectDisplayData(album.ImageAlbum, album.Name);
            }

            if (i_BaseFacebookObject is User)
            {
                User user = i_BaseFacebookObject as User;
                string location = user.Location == null ? "" : user.Location.Name;
                try
                {
                    ret = new FacebookObjectDisplayData(user.ImageSquare, $@"{UserWrapper.GetFullName(user)}
{user.Birthday}
{user.Gender}
{location}");
                }
                catch (System.Net.WebException)
                {
                    ret = new FacebookObjectDisplayData(Image.FromFile(r_NoImageFoundPicturePath), $@"{UserWrapper.GetFullName(user)}
{user.Birthday}
{user.Gender}
{location}");
                }
            }
            if (i_BaseFacebookObject is Page)
            {
                Page page = i_BaseFacebookObject as Page;
                ret = new FacebookObjectDisplayData(page.ImageNormal, page.Name);
            }

            if (ret != null)
            {
                return ret;
            }
            else
            {
                throw new ArgumentException("Unsupported object type for display: " + i_BaseFacebookObject.GetType().FullName);
            }
        }

    }

}
