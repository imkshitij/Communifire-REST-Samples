#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;


#endregion

namespace Communifire.RestApiSamples
{
    class Program
    {
        public static readonly string ROOT_URL = "http://star.communifire.com/services/";//http://localhost:499/
        public static readonly string API_KEY = "YWRtaW46YzdkZmE4MDgtNTAxNi00YjU5LTk1ZGItYzA4ZWU4Zjk5Njgz";
            //"YWRtaW46MjNjYTQ1NzktYWI2YS00MjEwLTgyNjUtZGNkZjFkYTA1Y2Vi";

        static void Main(string[] args)
        {
            UserServiceSample.CreateCase(1, "Star REST Issue", "Star REST Issue");
            #region Space Related
           
            //SpaceProgram.UnjoinUser(13, 1);
            //SpaceProgram.GetSpaceUrl(1);
            //ArticleSample.ArticleStubAvailability(0, "test-rest-api-artcile");// DONE
            //ArticleSample.SetArticleStatus(45,0);// DONE
            //ArticleSample.UpdateArticleViewCOunt(45,555);
            //ArticleSample.GetAllArticle();
            //ArticleSample.GetRelatedArticle(48);//DONE
            //ArticleSample.GetArticle(45);// DONE
            //ArticleSample.DeleteArticle(1);// DONE
            //ArticleSample.UpdateArticle();// DONE
            //ArticleSample.AddArticle();// DONE
            //ArticleSample.AssociateRelatedArticle(48, 45);//DONE
            //ArticleSample.UpdatePublishStatus(45);//DONEs
            //ArticleSample.GetTagsOfArticle(45);//DONE
            //ArticleSample.DeleteArticleRelation(45);//DONE
            //ArticleSample.GetArticlesSearched("test","10","0",null);
            //SpaceProgram.AddSpace();
            //SpaceProgram.GetSpace(1);
            //SpaceProgram.DeleteSpace(2);
            //SpaceProgram.GetSpace(2);
            //SpaceProgram.UpdateSpace();
            //SpaceProgram.GetSpace(13);
           // SpaceProgram.UnjoinUser(13,1);
            //SpaceProgram.AddSpaceRole();
            #endregion
            //AddUser();
            //GetUserByUserName("nidhigupta2");
            //GetUserByID(9);
            //DeleteUser(9);
            //SpaceProgram.AddSpace();
           // MapMarkerSample.UpdateMarkerCategory();
            Console.ReadLine();
        }

        public static void AddUser()
        {
            try
            {
                //Add a new user using the REST API in Communifire
                //create a user. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<DyveUserDTO><Email>user-email1@email.com</Email><FirstName>Nidhi</FirstName><LastName>Gupta</LastName><Password>NewUserPassword555</Password><UserName>nidhigupta2</UserName></DyveUserDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}userservice.svc/users", ROOT_URL);

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
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        //read the results string
                        string result = reader.ReadToEnd();
                        //check the results assuming XML is returned: note for JSON: use JSON stringfy
                        XmlDocument resultsXml = new XmlDocument();

                        resultsXml.LoadXml(result);
                        string userCreateStatus = resultsXml.GetElementsByTagName("UserCreateStatus")[0].InnerText;
                        if (userCreateStatus == "Success")
                            Console.WriteLine("User created successfully.");
                        else
                            Console.WriteLine("User add failed: " + userCreateStatus);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }

        public static void GetUserByUserName(string username)
        {
            try
            {
                //Get a community user using the REST API in Communifire based on username
                //set the RESTful URL
                string serviceUrl = string.Format("{0}userservice.svc/users/{1}", ROOT_URL, 9);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        //read the results string
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }

        public static void GetUserByID(int userID)
        {
            try
            {
                //Get a community user using the REST API in Communifire based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}userservice.svc/users/{1}", ROOT_URL, userID);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        //read the results string
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }

        public static void DeleteUser(int userID)
        {
            try
            {
                //Deletes a community user using the REST API based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}userservice.svc/users/{1}", ROOT_URL, userID);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", API_KEY);

                //post the request and get the response details
                using (var response = myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        //read the results string
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.Read();
        }
    }//end class
}//end namespace
