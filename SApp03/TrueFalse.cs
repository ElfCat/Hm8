﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SApp03
{
    public class TrueFalse
    {
        private string fileName;
        private List<Question> list;

        public string FileName
        {
            set { fileName = value; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count  && index >= 0)
                list.RemoveAt(index);
        }

        public Question this [int index]
        {
            get { return list[index]; }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fStream, list);
            }
        }
        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = (List<Question>)xmlSerializer.Deserialize(fStream);
            }
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}
