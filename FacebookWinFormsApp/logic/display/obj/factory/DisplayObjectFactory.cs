using FacebookWrapper.ObjectModel;
using System;

namespace BasicFacebookFeatures.logic.display.obj.factory
{
    public class DisplayObjectFactory
    {
        public static DisplayObject CreateDisplayObject(FacebookObject i_ObjectToDisplay)
        {
            DisplayObject ret = null;
            if (i_ObjectToDisplay is Album)
            {
                ret = new AlbumDisplayObject(i_ObjectToDisplay);
            }
            else if (i_ObjectToDisplay is User)
            {
                ret = new UserDisplayObject(i_ObjectToDisplay);
            }
            else if (i_ObjectToDisplay is Page)
            {
                ret = new PageDisplayObject(i_ObjectToDisplay);
            }
            else
            {
                throw new ArgumentException(@"DisplayObjectFactory may only create a DisplayObjects of the following types:
User, Page, Album.");
            }

            return ret;
        }
    }
}
