#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
  public  class ForumSample
    {
       // #region Forum

        //#region CRUD Methods
        public static void  CreateForum()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums",Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public void UpdateForum()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Update From Rest Forum</Description><ForumID>53</ForumID><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Updated Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums", Program.ROOT_URL);

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
                    if (response.ContentLength > 0)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToBoolean(forumCreateStatus))
                                    Console.WriteLine("Forum Updated successfully.");
                                else
                                    Console.WriteLine("Forum Updation failed.");

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
            Console.Read();

        }

        public void DeleteForum()
        {
            try
            { 
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/{1}", Program.ROOT_URL,1);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion

        //#region Get Methods
        public static void GetForum()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/{1}", Program.ROOT_URL,1);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
  
        public static void GetForums()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forum?groupID={1}&spaceID={2}&statusID={3}&isPrivate={4}&isModerated={5}&startDate={6}&endDate={7}&sortColumn={8}&sortOrder={9}&startPage={10}&pageLength={11}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void GetForumPermissions()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void GetForumsStatistics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/statistics?currentDateTime={1}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion


        public static void CheckStubAvailability()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forumavailability?spaceID={1}&forumStub={2}", Program.ROOT_URL,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void SetForumStatus()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forumstatus", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void CheckUserForumSubscription()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forumsubscription?forumID={1}&userID={2}", Program.ROOT_URL,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void ChangeForumSubscription()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forumsubscription", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void TurnOffForumWorkflow()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/forumworkflow", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        //#endregion Forum

        //#region Group

        //#region CRUD Methods
        public static void CreateGroup()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void UpdateGroup()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void DeleteGroup()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group/{1}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion

        //#region Get Methods
        public static void GetGroup()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group/{1}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void GetGroups()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/groups?status={1}&startPage={2}&pageLength={3}", Program.ROOT_URL,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void GetAllGroups()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        public static void GetGroupPermissions()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        //#endregion
        public static void CheckGroupStubAvailability()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group/groupavailability?groupStub={1}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void ChangeGroupStatus()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group/groupstatus", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion Group

        //#region Topic

        //#region CRUD Methods
        public static void CreateTopic()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topic", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void UpdateTopic()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topic", Program.ROOT_URL);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void DeleteTopic()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topic/{spaceID}/{1}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion

        //#region Get Methods
        public static void GetTopic()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topic/{1}/{2}", Program.ROOT_URL,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void GetTopics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/group/topic?groupID={1}&forumID={2}&spaceID={3}&userID={4}&totalPosts={5}&entityStatus={6}&dateRange={7}&currentDateTime={8}&sortColumn={9}&sortOrder={10}&startPage={11}&pageLength={12}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void GetSpaceTopics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/space/topic?spaceID={1}&status={2}&forumID={3}&totalPosts={4}&sortColumn={5}&sortOrder={6}&startPage={7}&pageLength={8}", Program.ROOT_URL,1,1,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }

        //public static void GetTopics()
        //{
        //    try
        //    {
        //        //Add a new forum using the REST API in Communifire
        //        //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}forumservice.svc/forums",Program.ROOT_URL);

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
        //                    //check the results assuming XML is returned: note for JSON: use JSON stringfy
        //                    XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
        //                    bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
        //                    if (isError)
        //                    {
        //                        string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
        //                        Console.Write(responseMessage);
        //                    }
        //                    else
        //                    {
        //                        string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
        //                        if (Convert.ToInt32(forumCreateStatus) > 0)
        //                            Console.WriteLine("Forum created successfully.");
        //                        else
        //                            Console.WriteLine("Forum add failed ");

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
        //    Console.Read();
        //}
        public static void GetTopicsByParticipatedUserID()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/participateduser?spaceID={1}&groupID={2}&forumID={3}&userID={4}&totalPosts={5}&statusID={6}&dateRange={7}&currentDateTime={8}&sortColumn={9}&sortOrder={10}&startPage={11}&pageLength={12}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void GetUnAnsweredTopics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/unansweredtopics?groupID={1}&forumID={2}&userID={3}&totalPosts={4}&statusID={5}&dateRange={6}&currentDateTime={7}&sortColumn={8}&sortOrder={9}&startPage={10}&pageLength={11}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void GetPopularTopics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/populartopics?forumID={1}&spaceID={2}&numberOfRecords={3}&isSpace={4}", Program.ROOT_URL,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        public static void GetSubscribedTopics()
        {
            try
            {
                //Add a new forum using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<ForumDTO><Description>Rest Forum</Description><GroupID>5</GroupID><GroupName>Rest Group </GroupName><GroupStub>rest-group</GroupStub><Hidden>false</Hidden><IsPrivate>0</IsPrivate><IsTested>false</IsTested><IsWorkflowActive>false</IsWorkflowActive><LastPosted>0001-01-01T00:00:00</LastPosted><Locked>false</Locked><MetaDescription></MetaDescription><MetaKeywords>Rest Meta Keyword</MetaKeywords><MetaTitle>Rest Meta Title</MetaTitle><Moderated>false</Moderated><Name>Rest name</Name><NumOfPosts>0</NumOfPosts><NumOfTopics>0</NumOfTopics><ParentID>0</ParentID><SpaceID>0</SpaceID><StatusID>0</StatusID><Stub>rest-forum</Stub><ThemeURL>Rest-Url</ThemeURL><UserID>1</UserID><UserName>admin</UserName><WorkflowID>0</WorkflowID></ForumDTO>";

                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/subscribedtopics?spaceID={1}&userID={2}&sortColumn={3}&sortOrder={4}&startPage={5}&pageLength={6}", Program.ROOT_URL,1,1,1,1,1,1);

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
                            //check the results assuming XML is returned: note for JSON: use JSON stringfy
                            XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                            bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                            if (isError)
                            {
                                string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                                Console.Write(responseMessage);
                            }
                            else
                            {
                                string forumCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                                if (Convert.ToInt32(forumCreateStatus) > 0)
                                    Console.WriteLine("Forum created successfully.");
                                else
                                    Console.WriteLine("Forum add failed ");

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
            Console.Read();
        }
        //#endregion

        public static void  ChangeTopicSubscription()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topicsubscription", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        public static void  CheckTopicSubscription()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/forumservice.svc/forums/topicsubscription?userID={1}&topicID={2}", Program.ROOT_URL,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void  MoveTopic()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/movetopic/{1}/{2}", Program.ROOT_URL,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void  SetTopicStatus(int topicID, int statusID)
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topicstatus/{1}/{2}", Program.ROOT_URL,topicID,statusID);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void  UpdateTopicViewCount()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/topicviewcount/{1}/{2}", Program.ROOT_URL,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void GetQueuedWorkflowTopics()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/workflowtopics?spaceID={1}&roleID={2}&startPage={3}&pageLength={4}", Program.ROOT_URL,1,1,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        //public static void GetQueuedWorkflowTopics()
        //{
        //    try
        //    {
        //        //Add a new user using the REST API in Communifire
        //        //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}userservice.svc/users",Program.ROOT_URL);

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
        //            using (var reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                //check the results assuming XML is returned: note for JSON: use JSON stringfy
        //                XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
        //                bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
        //                if(isError)
        //                {
        //                    string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
        //                    Console.Write(responseMessage);
        //                }
        //                else
        //                {
        //                    string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
        //                    if (userCreateStatus == "Success")
        //                        Console.WriteLine("User created successfully.");
        //                    else
        //                        Console.WriteLine("User add failed: " + userCreateStatus);
                            
        //                }
                        
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception.Message);
        //    }
        //    Console.Read();
        //}
            //#endregion Topic

        //#region Forum Post

        //#region CRUD Post Methods
        public static void  CreatePost()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        public static void  UpdatePost()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void  DeletePost()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/{1}", Program.ROOT_URL,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        //#endregion

        //#region Get Post Methods
        public static void GetPost()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/posts/post?postID={1}&isSpacePost={2}", Program.ROOT_URL,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void GetTopNPosts()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/forumservice.svc/forums/post/toppost?numberOfRecords={numberOfRecords}&userID={1}&spaceID={2}&isPrivate={3}", Program.ROOT_URL,1,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        public static void GetSpacePosts()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/spacepost?topicID={1}&statusID={2}&sortColumn={3}&sortOrder={4}&startPage={5}&pageLength={6}", Program.ROOT_URL,1,1,1,1,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        public static void GetPosts()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/forumpost?forumID={1}&topicID={2}&userID={3}&statusID={4}&updateViewCount={5}&dateRange={6}&currentDateTime={7}&sortColumn={8}&sortOrder={9}&startPage={10}&pageLength={11}", Program.ROOT_URL,1,1,1,1,1,1,1,1,1,1,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/tags?postID={1}", Program.ROOT_URL,1);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
        //#endregion


        public static void  ChangeAnsweredStatus()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/answeredstatus", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        public static void  SetPostStatus()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/status", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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

        //#endregion Forum Post

        public static void  MoveToNextWorkFlowStep()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}forumservice.svc/forums/post/workflow", Program.ROOT_URL);

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
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = DataLoadHelper.GetXmlDocument(reader);
                        bool isError = Convert.ToBoolean(DataLoadHelper.GetNodeValue(resultsXml, "IsError"));
                        if(isError)
                        {
                            string responseMessage = DataLoadHelper.GetNodeValue(resultsXml, "ResponseMessage");
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string userCreateStatus = DataLoadHelper.GetNodeValue(resultsXml, "ResponseData");
                            if (userCreateStatus == "Success")
                                Console.WriteLine("User created successfully.");
                            else
                                Console.WriteLine("User add failed: " + userCreateStatus);
                            
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
    }
}
