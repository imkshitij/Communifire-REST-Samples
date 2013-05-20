#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    public class CommonSample
    {
        public static void GetSearchResults()
        {
            try
            {
                string serviceUrl = string.Format("{0}commonservice.svc/search?searchText={3}&startPage={1}&pageLength={2}", Program.ROOT_URL, 1, 30, "s");

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";

                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);


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

        public static void GetGenericContent(string entityTypeCSV, string userIDCSV, string spaceIDCSV, string tagCSV, string tagIDCSV, string tagGroupIDCSV, string fromDate, string toDate, bool? isFeatured, 
            int? sortByColumn, int? sortOrderType, string searchKeyword, bool? searchOnlyTags, int startPage, int pageLength)
        {
            try
            {
                var query = new StringBuilder(string.Format("?startPage={0}&pageLength={1}", startPage, pageLength));
                
                if (entityTypeCSV != null)
                {
                    query.AppendFormat("&entityTypeCSV={0}", entityTypeCSV);
                }
                if (userIDCSV != null)
                {
                    query.AppendFormat("&userIDCSV={0}", userIDCSV);
                }
                if (spaceIDCSV != null)
                {
                    query.AppendFormat("&spaceIDCSV={0}", spaceIDCSV);
                }
                if (tagCSV != null)
                {
                    query.AppendFormat("&tagCSV={0}", tagCSV);
                }
                if (tagIDCSV != null)
                {
                    query.AppendFormat("&tagIDCSV={0}", tagIDCSV);
                }
                if (tagGroupIDCSV != null)
                {
                    query.AppendFormat("&tagGroupIDCSV={0}", tagGroupIDCSV);
                }
                if (fromDate != null)
                {
                    query.AppendFormat("&fromDate={0}", fromDate);
                }
                if (toDate != null)
                {
                    query.AppendFormat("&toDate={0}", toDate);
                }
                if (isFeatured != null)
                {
                    query.AppendFormat("&isFeatured={0}", isFeatured);
                }
                if (sortByColumn != null)
                {
                    query.AppendFormat("&sortByColumn={0}", sortByColumn);
                }
                if (sortOrderType != null)
                {
                    query.AppendFormat("&sortOrderType={0}", sortOrderType);
                }
                if (searchKeyword != null)
                {
                    query.AppendFormat("&searchKeyword={0}", searchKeyword);
                }
                if (searchOnlyTags != null)
                {
                    query.AppendFormat("&searchOnlyTags={0}", searchOnlyTags);
                }
                string serviceUrl =string.Format("{0}commonservice.svc/genericcontent{1}",Program.ROOT_URL, query);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);


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

        public static void GetTags()
        {
            try
            {
                string serviceUrl = string.Format("{0}commonservice.svc/tags?startPage={1}&pageLength={2}", Program.ROOT_URL, 1, 30);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";

                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);


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
        
        public static void AddTags(string tags, int spaceID, string entityType, int entityID)
        {
            try
            {
                string postData =
    string.Format(
        "<AddTags xmlns=\"http://tempuri.org/\"><tags>{0}</tags><spaceID>{1}</spaceID><entityType>{2}</entityType><entityID>{3}</entityID></AddTags>",
      tags, spaceID, entityType, entityID);

                string serviceUrl = string.Format("{4}commonservice.svc/tags?tags={0}&spaceID={1}&entityType={2}&entityID={3}", tags, spaceID, entityType, entityID, Program.ROOT_URL);

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

                            Console.WriteLine("Method successfully called.");

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

        ///// <summary>
        ///// Adds the tag.
        ///// </summary>
        ///// <param name="entityType">Type of the entity.</param>
        ///// <param name="entityID">The entity ID.</param>
        ///// <param name="tagName">Tag name</param>
        ///// <param name="spaceID">The space ID.</param>
        //public static void AddTag(string tagName,int spaceID ,int entityType,int entityID )
        //{
        //    try
        //    {
        //        string postData = string.Format("<TagDTO><EntityID>{0}</EntityID><EntityType>{1}</EntityType><SpaceID>{2}</SpaceID><TagName>{3}</TagName></TagDTO>",
        //            entityID, entityType, spaceID, tagName);
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}commonservice.svc/tags/tag", Program.ROOT_URL);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "POST";
        //        //set the content header type. Note: use "application/json" for JSON
        //        myRequest.ContentType = "application/xml";
        //        byte[] data = Encoding.UTF8.GetBytes(postData);
        //        myRequest.ContentLength = data.Length;
        //        //add the API key
        //        myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
        //        //add the data to be posted in the request stream
        //        var requestStream = myRequest.GetRequestStream();
        //        requestStream.Write(data, 0, data.Length);
        //        requestStream.Close();

        //        //post the request and get the response details
        //        using (var response = myRequest.GetResponse())
        //        {
        //            if (response.ContentLength > 0)
        //            {
        //                using (var reader = new StreamReader(response.GetResponseStream()))
        //                {

        //                    //read the results string
        //                    string result = reader.ReadToEnd();
        //                    //check the results assuming XML is returned: note for JSON: use JSON stringfy
        //                    XmlDocument resultsXml = new XmlDocument();
        //                    resultsXml.LoadXml(result);
        //                    bool isError = Convert.ToBoolean(resultsXml.GetElementsByTagName("IsError")[0].InnerText);
        //                    if (isError)
        //                    {
        //                        string responseMessage = resultsXml.GetElementsByTagName("ResponseMessage")[0].InnerText;
        //                        Console.Write(responseMessage);
        //                    }
        //                    else
        //                    {
        //                        string serviceResult = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
        //                        if (!string.IsNullOrEmpty(serviceResult))
        //                        {
        //                            Console.WriteLine("Method successfully called.");
        //                            Console.WriteLine(Environment.NewLine + string.Format("Result: {0} ", serviceResult));
        //                        }
        //                        else
        //                            Console.WriteLine("Method called but result is not accurate.");
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Failed because: 0 length content returned.");
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception.Message);
        //    }
        //}

        public static void GetUserAutoSuggestSearch(string searchText, int numberOfRecords)
        {
            try
            {
                string serviceUrl = string.Format("{0}commonservice.svc/users/userautosuggest?searchText={1}&numberOfRecords={2}", Program.ROOT_URL, searchText, numberOfRecords);
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/xml";

                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);

                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
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

        public static void GetSpaceAutoSuggestSearch(string searchText, int numberOfRecords)
        {
            try
            {
                string serviceUrl = string.Format("{0}commonservice.svc/spaces/spaceautosuggest?searchText={1}&numberOfRecords={2}", Program.ROOT_URL, searchText, numberOfRecords);
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/xml";

                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);

                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
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

        public static void GetActivityTickerResults(int? spaceID, int numberOfRecords)
        {
            try
            {
                var query = new StringBuilder(string.Format("?numberOfRecords={0}", numberOfRecords));

                if (spaceID != null)
                {
                    query.AppendFormat("&spaceID={0}", spaceID);
                }
                string serviceUrl = string.Format("{0}commonservice.svc/activity{1}", Program.ROOT_URL, query);
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                myRequest.ContentType = "application/xml";

                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);

                using (var response = myRequest.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
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
