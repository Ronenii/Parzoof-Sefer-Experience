using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.logic.display.obj
{
    public class PageDisplayObject: DisplayObject
    {
        public PageDisplayObject(FacebookObject i_ObjectToDisplay) : base(i_ObjectToDisplay)
        {
        }

        public override DisplayData getDisplayDataFromBaseObject(FacebookObject i_BaseFacebookObject)
        {
            Page basePage = i_BaseFacebookObject as Page;
            return new DisplayData(basePage.ImageNormal, basePage.Name);
        }

    }
}
