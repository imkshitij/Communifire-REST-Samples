#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    class IssueTrackerSample
    {
        public static readonly string ROOT_URL = "http://star.communifire.com";//http://localhost:499/
        public static readonly string API_KEY = "YWRtaW46ODAxZjlmNmMtZWE4NS00OWI1LTgyZTEtN2FlY2Q5YTZlN2Zm";


        public static string ClearifyIssueTracker(int spaceID, string useremail, string title, string description)
        {
            //call the Communifire REST layer to see if the user exists already:
            string userid = GetUserIDByEmail(useremail);
            if (!string.IsNullOrEmpty(userid))
            {
                int userID = Convert.ToInt32(userid);
                if (userID > 0)
                {
                    //user exists, submit ticket
                    CreateCase(spaceID, userID, title, description);
                }
            }
            else
            {
                //create new user
                //check email avail first
                string result = CheckEmailAvailablity(useremail);
                if (result.Equals("false"))
                    return "Email not available";
                else
                {
                    //create user with this email
                    string username;
                    string firstname;
                    string lastname = null;
                    string password;
                    string[] emailarray = useremail.Split('@');
                    int userID = Convert.ToInt32(AddUser(useremail, emailarray[0], emailarray[0], string.Empty, "test"));
                    CreateCase(spaceID, userID, title, description);
                }
            }
            return string.Empty;
        }
   
    
        public static void AddIssue()
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<IssueDTO><DateCreated>2012-01-12T00:07:00</DateCreated><IssueDescription>This issue is added via the WCF Service.</IssueDescription><IssueTitle>WCF Issue</IssueTitle><IssueStatusID>1</IssueStatusID><ProjectID>35</ProjectID><ProjectSectionID>1</ProjectSectionID><ReportedByUserID>1</ReportedByUserID></IssueDTO>";
                //string postData = string.Format("<ArticleDTO><AnonymousComments>false</AnonymousComments><ArticleBody>{0}</ArticleBody><ArticleImage></ArticleImage><ArticleStatusID>1</ArticleStatusID><ArticleURL></ArticleURL><Author></Author><AvatarPath></AvatarPath><CategoryID>1</CategoryID><Headline>{1}</Headline><IsFeatured>{2}</IsFeatured><IsLatest>false</IsLatest><IsPrivateSpace>false</IsPrivateSpace><IsPublishedFromDelayedPublishingMode>false</IsPublishedFromDelayedPublishingMode><IsPublishedFromDraftMode>false</IsPublishedFromDraftMode><LicenseID>0</LicenseID><MediaServerID>1</MediaServerID><MetaDescription>Article Meta Description</MetaDescription><MetaKeywords>Article Meta Keywords</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><SEOName>{3}</SEOName><SpaceID>0</SpaceID><StatusID>1</StatusID><Summary>test-rest-api-artcile</Summary><TagName>a,b,c</TagName><UserID>{4}</UserID></ArticleDTO>", artilceBody, headline, isfeatured, articlestub, userID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}issuetracker/issuetrackerservice.svc/case", Program.ROOT_URL);

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

        public static void CreateCase(int spaceID, int userid, string title, string description)
        {
            CreateCase(spaceID, userid, title, description, 61, 7, 231, 5, false);
        }
    
        public static void CreateCase(int spaceID, int userid, string title, string description, int projectID, int statusID, int projectSectionID, int priorityID, bool isTaskItem)
        {
            string postData =
                string.Format(
                    "<IssueDTO><IssueDescription>{0}</IssueDescription><IssuePriorityID>{1}</IssuePriorityID><IssueStatusID>{2}</IssueStatusID><IssueTitle>{3}</IssueTitle><IsTaskItem>{4}</IsTaskItem><ProjectID>{5}</ProjectID><ProjectSectionID>{6}</ProjectSectionID><ReportedByUserID>{7}</ReportedByUserID><SpaceID>{8}</SpaceID></IssueDTO>",
                    description, priorityID, statusID, title, isTaskItem, projectID, projectSectionID, userid, spaceID);

            //set the RESTful URL
            string serviceUrl = string.Format("{0}/services/issuetrackerservice.svc/case",
                                              Program.ROOT_URL);

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
                        bool isError =
                            Convert.ToBoolean(resultsXml.GetElementsByTagName("IsError")[0].InnerText);
                        if (isError)
                        {
                            string responseMessage =
                                resultsXml.GetElementsByTagName("ResponseMessage")[0].InnerText;
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string serviceResult =
                                resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (!string.IsNullOrEmpty(serviceResult))
                            {
                                //
                            }
                        }
                    }
                } //if response contentLength
            }
        }

        public static void CreateCaseComment(int issueID, int userid, string commentText)
        {
            string postData =
                string.Format(
                    "<IssueCommentDTO><CommentText>{0}</CommentText><IssueID>{1}</IssueID><UserID>{2}</UserID></IssueCommentDTO>",
                   commentText, issueID, userid);

            //set the RESTful URL
            string serviceUrl = string.Format("{0}/services/issuetrackerservice.svc/casecomment",
                                              Program.ROOT_URL);

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
                        bool isError =
                            Convert.ToBoolean(resultsXml.GetElementsByTagName("IsError")[0].InnerText);
                        if (isError)
                        {
                            string responseMessage =
                                resultsXml.GetElementsByTagName("ResponseMessage")[0].InnerText;
                            Console.Write(responseMessage);
                        }
                        else
                        {
                            string serviceResult =
                                resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                            if (!string.IsNullOrEmpty(serviceResult))
                            {
                                //
                            }
                        }
                    }
                } //if response contentLength
            }
        }

        public static string CheckEmailAvailablity(string email)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/services/userservice.svc/users/user?userEmail={1}", ROOT_URL, email.Trim());

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);
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
                                return "-1";
                            }
                            else
                            {
                                string serviceResult = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
                                if (!string.IsNullOrEmpty(serviceResult))
                                {
                                    return serviceResult;
                                }
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
            return string.Empty;
        }

        /// <summary>
        /// Gets the user ID by email.
        /// </summary>
        public static string GetUserIDByEmail(string email)
        {
            string retValue = string.Empty;
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/services/userservice.svc/users/userinfo?searchText={1}&infoType=1", ROOT_URL, email);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);

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
                                retValue = resultsXml.GetElementsByTagName("ResponseMessage")[0].InnerText;
                            }
                            else
                            {
                                retValue = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
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
            return retValue;
        }

        public static string AddUser(string email, string username, string firstname, string lastname, string password)
        {
            string serviceResult = string.Empty;
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = string.Format("<DyveUserDTO><Email>{0}</Email><FirstName>{1}</FirstName><IsActivated>true</IsActivated><LastName>{2}</LastName><Password>{3}</Password><UserName>{4}</UserName></DyveUserDTO>", email, firstname, lastname, password, username);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/services/userservice.svc/users", ROOT_URL);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "POST";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                myRequest.ContentLength = data.Length;
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);
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
                                serviceResult = resultsXml.GetElementsByTagName("ResponseData")[0].InnerText;
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
            return serviceResult;//userID returned
        }
    }//end class
}
