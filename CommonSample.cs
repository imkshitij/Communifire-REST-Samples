#region Using Directives

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#endregion

namespace Communifire.RestApiSamples
{
    public class CommonSample
    {
        public static void GetGenericContent()
        {
            try
            {
                string postData = "<GenericContentSearchFilterDTO></GenericContentSearchFilterDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}commonservice.svc/genericcontent?startPage={1}&pageLength={2}", Program.ROOT_URL, 1, 30);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        //read the results string
                        string result = reader.ReadToEnd();
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = new XmlDocument();
                        resultsXml.LoadXml(result);
                        bool isError = Convert.ToBoolean(resultsXml.GetElementsByTagName("IsError")[0].InnerText);
                        if (isError)
                        {
                            string responseMessage = resultsXml.GetElementsByTagName("ResponseMessage")[0].InnerText;
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string serviceResult = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (!string.IsNullOrEmpty(serviceResult))
                            {
                                Console.WriteLine("Method successfully called.");
                                Console.WriteLine(Environment.NewLine + string.Format("Result: {0} ", serviceResult));
                            }
                            else
                                Console.WriteLine("Method called but result is not accurate.");
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }

    }// end class
}// end namespace
