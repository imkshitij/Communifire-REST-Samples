#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    public class NotificationSample
    {
        public static void MarkNotificationsAsRead()
        {
            try
            {
                string notificationIDCSV = "29,30";

                string postData =
                    string.Format("<MarkNotificationsAsRead xmlns=\"http://tempuri.org/\"><notificationIDCSV>{0}</notificationIDCSV></MarkNotificationsAsRead>", notificationIDCSV);
                
                //set the RESTful URL
                string serviceUrl = string.Format("{0}NotificationsService.svc/notifications/status", Program.ROOT_URL);
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
                            Console.WriteLine("Success");
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

        public static void CreateNewNotification()
        {
            try
            {

                string postData = @"<Notification>
                                        <ActivityAction>Create</ActivityAction>
                                        <EntityID>0</EntityID>
                                        <EntityTypeID>501</EntityTypeID>
                                        <FromUser>
                                            <UserID>3</UserID>
                                        </FromUser>
                                        <Space>
                                            <SpaceID>2</SpaceID>
                                        </Space>
                                        <ToUser>
                                            <UserID>1</UserID>
                                        </ToUser>
                                    </Notification>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}NotificationsService.svc/notifications/notification", Program.ROOT_URL);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "POST";
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
                    else
                    {
                        Console.WriteLine("Failed because: 0 length content returned.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        public static void GetNotifications()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}NotificationsService.svc/notifications?startPage={1}&numberOfRecords={2}", Program.ROOT_URL, 1, 25);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);

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
                    else
                    {
                        Console.WriteLine("Failed because: 0 length content returned.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

    }// end class
}// end namespace
