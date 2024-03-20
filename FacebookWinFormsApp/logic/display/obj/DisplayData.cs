using System.Drawing;


namespace BasicFacebookFeatures.logic.display.obj
{
    public class DisplayData
    {
        private readonly Image r_Image;
        private readonly string r_DisplayedText;
        public DisplayData(Image i_Image, string i_DisplayedText)
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
}
