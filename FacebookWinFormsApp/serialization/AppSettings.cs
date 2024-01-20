using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;


namespace BasicFacebookFeatures.serialization
{
    public class AppSettings
    {
        public Point LastWindowLocation { get; set; }
        public Size LastWindowSize { get; set; }
        public bool RememberUser { get; set; }
        public string LastAccessToken { get; set; }

        private AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
        }

        public void SaveToFile()
        {
            string pathToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "temp", "appSettings.xml");

            if(!File.Exists(pathToSave))
            {
                XmlWriter.Create(pathToSave).Close();
            }

            using (Stream stream = new FileStream(pathToSave, FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromFile()
        {
            string pathToLoad = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "temp", "appSettings.xml");
            AppSettings res = new AppSettings();

            if(File.Exists(pathToLoad))
            {
                using(Stream stream = new FileStream(pathToLoad, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    res = serializer.Deserialize(stream) as AppSettings;
                }
            }

            return res;
        }
    }
}
