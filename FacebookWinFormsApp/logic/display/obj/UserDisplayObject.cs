using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.IO;

using BasicFacebookFeatures.logic.user.wrapper;

namespace BasicFacebookFeatures.logic.display.obj
{
    public class UserDisplayObject : DisplayObject
    {
        private const string k_NoImageFoundFileName = "No image found.png";
        private readonly string r_NoImageFoundPicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "res", k_NoImageFoundFileName);

        public UserDisplayObject(FacebookObject i_ObjectToDisplay) : base(i_ObjectToDisplay)
        {
        }

        public override DisplayData getDisplayDataFromBaseObject(FacebookObject i_BaseFacebookObject)
        {
            DisplayData ret = null;
            User baseUser = i_BaseFacebookObject as User;
            string location = baseUser.Location == null ? "" : baseUser.Location.Name;
            try
            {
                ret = new DisplayData(baseUser.ImageSquare, $@"{UserWrapper.GetFullName(baseUser)}
{baseUser.Birthday}
{baseUser.Gender}
{location}");
            }
            catch (System.Net.WebException)
            {
                ret = new DisplayData(Image.FromFile(r_NoImageFoundPicturePath), $@"{UserWrapper.GetFullName(baseUser)}
{baseUser.Birthday}
{baseUser.Gender}
{location}");
            }

            return ret;
        }
    }
}
