#region Using Directives

using System.IO;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    public class DataLoadHelper
    {
        public const string APIKeyToken = "YWRtaW46YzU5NTNjN2QtMjZlYS00ZDViLWExNDAtNDE1ZDNhNmViOThh";

        public static XmlDocument GetXmlDocument(string xmlPath)
        {
            //load the XML file
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            //convert XML to string
            StringWriter stringWriter = new StringWriter();
            xmlDocument.WriteTo(new XmlTextWriter(stringWriter));

            return xmlDocument;
        }

        public static string GetNodeValue(XmlDocument xmlDoc, string node)
        {
            return xmlDoc.GetElementsByTagName(node)[0].InnerText;
        }

        public static string GetXmlAsString(string xmlPath)
        {
            //load the XML file
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            //convert XML to string
            StringWriter stringWriter = new StringWriter();
            xmlDocument.WriteTo(new XmlTextWriter(stringWriter));

            return stringWriter.ToString();
        }

        public static string GetApIKeyToken()
        {
            return string.Format("Rest-Api-Key:{0}", APIKeyToken);
        }

        public static XmlDocument GetXmlDocument(StreamReader reader)
        {
            //read the results string
            string result = reader.ReadToEnd();
            var resultsXml = new XmlDocument();
            resultsXml.LoadXml(result);
            return resultsXml;
        }

        public static string GetNodeValue(StreamReader reader,string node)
        {

            //read the results string
            string nodeValue = "";
            string result = reader.ReadToEnd();
            var resultsXml = new XmlDocument();
            resultsXml.LoadXml(result);
             nodeValue=resultsXml.GetElementsByTagName(node)[0].InnerText;
            return nodeValue;
        }


    }//end class
}//end namespace
