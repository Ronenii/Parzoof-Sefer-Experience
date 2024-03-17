using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.IO;
using BasicFacebookFeatures.session;

namespace BasicFacebookFeatures.logic.display.obj
{
    public abstract class DisplayObject
    {
        private readonly Image r_Image;
        private readonly string r_DisplayedText;
        public DisplayObject(FacebookObject i_ObjectToDisplay)
        {
            DisplayData facebookObjectDisplayData = getDisplayDataFromBaseObject(i_ObjectToDisplay);
            r_Image = facebookObjectDisplayData.GetImage();
            r_DisplayedText = facebookObjectDisplayData.GetDisplayedText();
        }

        public Image GetImage()
        {
            return r_Image;
        }
        public string GetDisplayedText()
        {
            return r_DisplayedText;
        }

        public abstract DisplayData getDisplayDataFromBaseObject(FacebookObject i_BaseFacebookObject);

    }

}
