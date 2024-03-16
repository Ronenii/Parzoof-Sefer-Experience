using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFacebookFeatures.logic.grid;
using FacebookWrapper.ObjectModel;
using System.Reflection;
using BasicFacebookFeatures.session;

namespace BasicFacebookFeatures.logic.display.factory
{
    public static class GridFactory<T>
    {
        public static FacebookObjectDisplayGrid<T> CreateGrid()
        {
            FacebookObjectDisplayGrid<T> res = null;

            switch (typeof(T).ToString())
            {
                case "Album":
                    res = new FacebookObjectDisplayGrid<T>(UserWrapper.GetAlbums);
                    break;
                case "User":
                    res = new FacebookObjectDisplayGrid<T>(UserWrapper.GetFriends);
                    break;
                case "Page":
                    res = new FacebookObjectDisplayGrid<T>(UserWrapper.GetLikedPages);
                    break;
            }

            return res;
        }
    }
}
