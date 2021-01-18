using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace UnitEditor
{
    public class AtomSerializer
    {

        public static T Load<T>(string filePath)
            where T:class
        {
            if (!File.Exists(filePath))
                return Activator.CreateInstance<T>();
            using(FileStream fs = File.OpenRead(filePath)){
                return Load<T>(fs);
            };
        }

        public static T Load<T>(FileStream fs)
            where T:class
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T retVal = xs.Deserialize(fs) as T;
            return retVal ?? Activator.CreateInstance<T>();
        }

        public static void Save<T>(T item, string filePath) where T : class
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
            using (FileStream fs = File.OpenWrite(filePath))
            {
                Save(item, fs);
            }
        }

        public static void Save<T>(T item, FileStream fs) where T:class
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(fs, item);
        }

    }
}
