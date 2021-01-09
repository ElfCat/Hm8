using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SApp02
{
    class Program
    {
        
        public static Person LoadPersonFromXml(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (Stream fSteam = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return (xmlSerializer.Deserialize(fSteam) as Person);
            }
        }

        public static void SavePersonFromXml(Person person, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (Stream fSteam = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                xmlSerializer.Serialize(fSteam, person);
            }
        }



        static void Main(string[] args)
        {
            var person = LoadPersonFromXml(AppDomain.CurrentDomain.BaseDirectory + "Person.xml");
            person.Age = 54;
            SavePersonFromXml(person, AppDomain.CurrentDomain.BaseDirectory + "Person.xml");


        }
    }
}
