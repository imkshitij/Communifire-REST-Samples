#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    class EventSample
    {
        #region Event Related Methods

        #region CRUD Methods
        public void CreateEvent() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<EventDTO><Address></Address><CreatedOnDate>0001-01-01T00:00:00</CreatedOnDate><Description>Description</Description><EndDate>0001-01-01T00:00:00</EndDate><EntryDate>0001-01-01T00:00:00</EntryDate><EventStatusID>1</EventStatusID><EventTypeID>1</EventTypeID><EventTypeName>Test EventType</EventTypeName><EventURL></EventURL><IsFeatured>false</IsFeatured><IsOnline>false</IsOnline><IsPrivateSpace>false</IsPrivateSpace><Keywords></Keywords><MediaServerRootURL>1</MediaServerRootURL><Organization>Communifire</Organization><SpaceID>1</SpaceID><StartDate>0001-01-01T00:00:00</StartDate><Telephone>1234567</Telephone><Title>Test Event</Title><UserID>1</UserID><VenueName>USA</VenueName><Views>0</Views><Website>www.test.com</Website><WhoShouldAttend></WhoShouldAttend><Zip></Zip></EventDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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

        public void UpdateEvent() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<EventDTO><Address></Address><CreatedOnDate>0001-01-01T00:00:00</CreatedOnDate><Description>Description</Description><EndDate>0001-01-01T00:00:00</EndDate><EntryDate>0001-01-01T00:00:00</EntryDate><EventID>1</EventID><EventStatusID>1</EventStatusID><EventTypeID>1</EventTypeID><EventTypeName>Test EventType</EventTypeName><EventURL></EventURL><IsFeatured>false</IsFeatured><IsOnline>false</IsOnline><IsPrivateSpace>false</IsPrivateSpace><Keywords></Keywords><MediaServerRootURL>1</MediaServerRootURL><Organization>Communifire</Organization><SpaceID>1</SpaceID><StartDate>0001-01-01T00:00:00</StartDate><Telephone>1234567</Telephone><Title>Test Event</Title><UserID>1</UserID><VenueName>USA</VenueName><Views>0</Views><Website>www.test.com</Website><WhoShouldAttend></WhoShouldAttend><Zip></Zip></EventDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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

        public void DeleteEvent(int eventID) 
        {
            try
            {
                //Deletes a community user using the REST API based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/{1}", Program.ROOT_URL, 1);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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
                        string spaceUpdateStatus = resultsXml.GetElementsByTagName("boolean")[0].InnerText;
                        if (spaceUpdateStatus == "false")
                            Console.WriteLine("Space delete failed");
                        else
                            Console.WriteLine("Space deleted successfully");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }
        public void GetEvent(int eventID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void UpdateEventViewCount(int eventID, long viewCount) 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventviewcount?eventID={1}&viewCount={2}", Program.ROOT_URL,1,1);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        #endregion CRUD Methods

        #region Events GET Methods
        public void GetEvents(int? userID, int spaceID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/user?userID={1}&spaceID={2}", Program.ROOT_URL,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void FindSubscribedEvents(int userID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/subscribedevents?userID={1}&spaceID={2}&attendanceType={3}&dateRangeType={4}", Program.ROOT_URL,1,1,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void GetEvents() 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventslist?userID={1}&spaceID={2}&entityStatus={3}&eventType={4}&startDate={5}&endDate={6}&venueName={7}&keywords={8}&month={9}&sortColumn={10}&sortOrder={11}&dateRange={12}&startPage={13}&pageLength={14}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1,1,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        
        public void SetEventStatus() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventstatus?eventID={1}&statusID={2}", Program.ROOT_URL,1,1);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        #endregion Events GET Methods

        #region Event Attendance

        #region CRUD
        public void CreateAttendUser() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        public void UpdateUserAttendance() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/userattendance?eventID={1}&userID={2}&attendanceType={3}", Program.ROOT_URL,1,1,1);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        #endregion  CRUD

        #region GET Methods
        public void GetSubscribedEvents() 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/blog/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void GetEventAttendUsers(int eventID, int attendanceTypeID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventattendusers?eventID={1}&attendanceTypeID={2}", Program.ROOT_URL,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void GetEventRSVP(int userID, int eventID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventRSVP?userID={1}&eventID={2}", Program.ROOT_URL,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        #endregion GET Methods

        public void AddSpaceEventInvitation(int spaceID, int eventID, bool  isAttendee, int inviteSpaceID) 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/eventinvitation?spaceID={1}&eventID={2}&isAttendee={3}&inviteSpaceID={4}", Program.ROOT_URL,1,1,1,1);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        public void GetEventAttendees(int eventID, bool  isAttending) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/event/EventAttendees?eventID={1}&isAttending={2}", Program.ROOT_URL,1,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        #endregion
        #endregion Event Related Methods

        #region EventType Related Methods

        #region CRUD Methods

        public void AddEventType() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<EventTypeDTO><EventTypeName>eventTypeName</EventTypeName><SpaceID>0</SpaceID></EventTypeDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventtype", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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

        public void UpdateEventType() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<EventTypeDTO><EventTypeID>1</EventTypeID><EventTypeName>eventTypeName</EventTypeName><SpaceID>0</SpaceID></EventTypeDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventtype", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        public void DeleteEventType(int eventTypeID) 
        {
            try
            {
                //Deletes a community user using the REST API based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventtype/{1}", Program.ROOT_URL, 1);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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
                        string spaceUpdateStatus = resultsXml.GetElementsByTagName("boolean")[0].InnerText;
                        if (spaceUpdateStatus == "false")
                            Console.WriteLine("Space delete failed");
                        else
                            Console.WriteLine("Space deleted successfully");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }
        #endregion

        public void GetEventType(int eventTypeID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventtype/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void GetEventTypes(int spaceID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/blog/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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

        #endregion EventType Related Methods

        #region Event Comment Related Methods

        #region CRUD Methods
        public void CreateComment() 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<EventCommentDTO><CommentText>Test event Comment </CommentText><EventID>1<EventID><StatusID>1</StatusID><UserID>1</UserID></EventCommentDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventcomment", Program.ROOT_URL);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        public void DeleteComment(int commentID) 
        {
            try
            {
                //Deletes a community user using the REST API based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventcomment/{commentID}", Program.ROOT_URL, 1);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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
                        string spaceUpdateStatus = resultsXml.GetElementsByTagName("boolean")[0].InnerText;
                        if (spaceUpdateStatus == "false")
                            Console.WriteLine("Space delete failed");
                        else
                            Console.WriteLine("Space deleted successfully");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }
        #endregion

        public void SetCommentStatus(int commentID, int statusID) 
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventcomment/commentstatus?commentID={1}&statusID={2}", Program.ROOT_URL,1,1);

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

                            string articleCreateStatus = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (articleCreateStatus == "Error")
                                Console.WriteLine("Article created failed");
                            else
                                Console.WriteLine("Article created successfully: " + articleCreateStatus);
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
        public void GetComment(int eventCommentID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventcomment/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
        public void GetComments(int eventID) 
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}eventservice.svc/events/eventcomment/commentslist/{1}", Program.ROOT_URL,1);

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
                            string articleStatistics = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            //int resultArticleID = Convert.ToInt32(DataLoadHelper.GetNodeValue(resultsXml, "ArticleID"));
                            if (articleStatistics != "Error")
                            {
                                Console.WriteLine("Successfully get the article statistics.");
                                Console.WriteLine(articleStatistics);
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
       
        #endregion Event Comment Related Methods
    }
}
