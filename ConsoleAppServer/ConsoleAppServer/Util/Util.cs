using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleAppServer.Util
{
    public  class Util
    {
        public static string Serialize(object o)
        {

            //加上Namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");


            XmlSerializer ser = new XmlSerializer(o.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, o, ns);

            //格式化
            XDocument doc = XDocument.Parse(sb.ToString());

            return doc.ToString();
        }

        public static T Deserialize<T>(string s)
        {
            XmlDocument xdoc = new XmlDocument();

            try
            {
                xdoc.LoadXml(s);
                XmlNodeReader reader = new XmlNodeReader(xdoc.DocumentElement);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                object obj = ser.Deserialize(reader);

                return (T)obj;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
