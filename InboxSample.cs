#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    public class InboxSample
    {
        public static void AddThreadParticipants()
        {
            try
            {
                string apikey = DataLoadHelper.GetApIKeyToken();
                int threadID = 20;
                string participants = "12";
                string postData =
                    string.Format(
                        "<AddThreadParticipants xmlns=\"http://tempuri.org/\"><threadID>{0}</threadID><participants>{1}</participants></AddThreadParticipants>",
                        threadID, participants);

                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/thread/participants", Program.ROOT_URL);
                //set the content header type. Note: use "json" for JSON
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add(apikey);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            Console.WriteLine("Method successfully called.");;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void CreateMessage()
        {
            try
            {
                string xmlPath = "TestData/MessageData.xml";
                string apikey = DataLoadHelper.GetApIKeyToken();

                string postData = DataLoadHelper.GetXmlAsString(xmlPath);

                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/message", Program.ROOT_URL);
                //set the content header type. Note: use "json" for JSON
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add(apikey);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = DataLoadHelper.GetNodeValue(reader, "ResponseData");
                            if (!string.IsNullOrEmpty(result))
                            {
                                if (Convert.ToInt32(result)>0)
                                {
                                    Console.WriteLine("Method successfully called.");
                                }
                                else
                                {
                                    Console.WriteLine("Method called but result is not accurate.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void DeleteMessage()
        {
            try
            {
                string apikey = DataLoadHelper.GetApIKeyToken();

                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/message/128", Program.ROOT_URL);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //add the API key
                myRequest.Headers.Add(apikey);

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
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
                                Console.WriteLine("Failed");
                            }
                            else
                            {
                                Console.WriteLine("Method successfully called.");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void DeleteMessageThread()
        {
            try
            {
                string apikey = DataLoadHelper.GetApIKeyToken();

                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/thread/19", Program.ROOT_URL);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //add the API key
                myRequest.Headers.Add(apikey);

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
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
                                Console.WriteLine("Failed");
                            }
                            else
                            {
                                Console.WriteLine("Method successfully called.");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void MarkMessagesAsRead()
        {
            try
            {

                string threadIDCSV = "21";

                string postData =
                    string.Format("<MarkMessagesAsRead xmlns=\"http://tempuri.org/\"><threadIDCSV>{0}</threadIDCSV></MarkMessagesAsRead>", threadIDCSV);


                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/status", Program.ROOT_URL);
                //set the content header type. Note: use "json" for JSON
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();


                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            Console.WriteLine("Method successfully called.");;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void UpdateMessageReadStatus()
        {
            try
            {
                string xmlPath = "TestData/MessageRecipientData.xml";
                string postData = DataLoadHelper.GetXmlAsString(xmlPath);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}InboxService.svc/messages/message/status", Program.ROOT_URL);
                //set the content header type. Note: use "json" for JSON
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();


                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            Console.WriteLine("Method successfully called.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Method called but result is not accurate.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Failed because:{0}", exception.Message));
            }
        }
        
        public static void GetConversationByUsers()
        {
            string serviceUrl = Program.ROOT_URL + string.Format("InboxService.svc/messages/thread?firstUserID={0}&secondUserID={1}&numberOfRecords={2}", 1, 284, 25);
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var messages = DataLoadHelper.GetNodeValue(reader, "ResponseData");
                        //Assert.AreEqual(true, Convert.ToBoolean(DataLoadHelper.GetNodeValue(reader, "IsActive")));
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
        
        public static void GetMesesage()
        {
            string xmlPath = "TestData/MessageData.xml";
            string messageID = DataLoadHelper.GetNodeValue(DataLoadHelper.GetXmlDocument(xmlPath), "MessageID");
            string serviceUrl = Program.ROOT_URL + string.Format("InboxService.svc/messages/message/{0}", messageID);
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        if (messageID == DataLoadHelper.GetNodeValue(reader, "MessageID"))
                        {
                            Console.WriteLine("Method successfully called.");
                        }
                        else
                        {
                            Console.WriteLine("Method called but result is not accurate.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
        
        public static void GetMessages()
        {
            string serviceUrl = Program.ROOT_URL + string.Format("InboxService.svc/messages/thread/{0}?numberOfRecords={1}", 20, 25);
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());

            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var messages = DataLoadHelper.GetNodeValue(reader, "ResponseData");
                        //Assert.AreEqual(true, Convert.ToBoolean(DataLoadHelper.GetNodeValue(reader, "IsActive")));
                       Console.WriteLine("Method successfully called.");
                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
        
        public static void GetMesesageThread()
        {
            string xmlPath = "TestData/MessageData.xml";
            string threadID = DataLoadHelper.GetNodeValue(DataLoadHelper.GetXmlDocument(xmlPath), "ThreadID");
            string serviceUrl = Program.ROOT_URL + string.Format("InboxService.svc/messages/thread/{0}", threadID);
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        if (threadID == DataLoadHelper.GetNodeValue(reader, "ThreadID"))
                        {
                            Console.WriteLine("Method successfully called.");
                        }
                        else
                        {
                            Console.WriteLine("Method called but result is not accurate.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
        
        public static void GetMessageThreads()
        {
            string serviceUrl = Program.ROOT_URL + string.Format("InboxService.svc/messages/threads?startPage={0}&numberOfRecords={1}", 1, 25);
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());

            myRequest.Headers.Add(string.Format("Rest-Impersonate-User:{0}", 4));

            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var messageThreads = DataLoadHelper.GetNodeValue(reader, "ResponseData");
                        //Assert.AreEqual(true, Convert.ToBoolean(DataLoadHelper.GetNodeValue(reader, "IsActive")));
                       Console.WriteLine("Method successfully called.");
                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
        
        public static void GetUnReadMessageCount()
        {
            string serviceUrl = Program.ROOT_URL + "InboxService.svc/messages/unread";
            var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/xml";
            myRequest.Headers.Add(DataLoadHelper.GetApIKeyToken());
            //post the request and get the response details
            using (var response = myRequest.GetResponse())
            {
                if (response.ContentLength > 0)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        int count = Convert.ToInt32(DataLoadHelper.GetNodeValue(reader, "ResponseData"));
                        if (count > -1)
                        {
                            Console.WriteLine("Method successfully called.");
                        }
                        else
                        {
                            {
                                Console.WriteLine("Method called but result is not accurate.");

                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Method called but result is not accurate.");
                }
            }
        }
    }// end class
}// end namespace
