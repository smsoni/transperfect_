using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WahooFitnessFramework
{
    public static class ReadXMLToClass
    {
        public static T ReadFromXMLFile<T>(string _filePath)
        {
            T obj;
            ILog log = LogManager.GetLogger(typeof(ReadXMLToClass).Name);
            log.DebugFormat(String.Format(@"File loaded: {1}\{0}", _filePath, System.IO.Directory.GetCurrentDirectory()));

            using (var reader = new StreamReader(_filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                var tDes = serializer.Deserialize(reader);
                obj = (T)tDes;
            }
            return obj;
        }
    }

    public static class WriteObjectToXML
    {
        public static bool WriteToXMLFile<T>(string _filePath, T _obj)
        {
            //using (var reader = XmlWriter.Create(_filePath))
            //{
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                try
                {
                    //serializer.Serialize(reader, _obj);
                    return true;
                }
                catch
                {
                    return false;
                }
           // }
            
        }

        public static string GetXML<T>(T _obj)
        {
            var stringWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                serializer.Serialize(stringWriter, _obj);

            }
            catch { }
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}
