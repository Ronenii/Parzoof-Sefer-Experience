using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.logic.display.obj
{
    public class AlbumDisplayObject : DisplayObject
    {
        public AlbumDisplayObject(FacebookObject i_ObjectToDisplay) : base(i_ObjectToDisplay)
        {
        }

        public override DisplayData getDisplayDataFromBaseObject(FacebookObject i_BaseFacebookObject)
        {
            Album baseAlbum = i_BaseFacebookObject as Album;
            return new DisplayData(baseAlbum.ImageAlbum, baseAlbum.Name);
        }
    }
}
