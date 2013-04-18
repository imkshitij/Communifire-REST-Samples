#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{

    class ArticleSample
    {
        #region Article Related
        #region Add Article
        /// <summary>
        /// Adds the article.
        /// </summary>
        public static void AddArticle()
        {
            try
            {
                string postData = "<ArticleDTO><ArticleBody>This artcle is added from the WCF Service.</ArticleBody><CategoryID>1</CategoryID><Headline>New Rest API WCF Article</Headline></ArticleDTO>";
                //string postData = string.Format("<ArticleDTO><AnonymousComments>false</AnonymousComments><ArticleBody>{0}</ArticleBody><ArticleImage></ArticleImage><ArticleStatusID>1</ArticleStatusID><ArticleURL></ArticleURL><Author></Author><AvatarPath></AvatarPath><CategoryID>1</CategoryID><Headline>{1}</Headline><IsFeatured>{2}</IsFeatured><IsLatest>false</IsLatest><IsPrivateSpace>false</IsPrivateSpace><IsPublishedFromDelayedPublishingMode>false</IsPublishedFromDelayedPublishingMode><IsPublishedFromDraftMode>false</IsPublishedFromDraftMode><LicenseID>0</LicenseID><MediaServerID>1</MediaServerID><MetaDescription>Article Meta Description</MetaDescription><MetaKeywords>Article Meta Keywords</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><SEOName>{3}</SEOName><SpaceID>0</SpaceID><StatusID>1</StatusID><Summary>test-rest-api-artcile</Summary><TagName>a,b,c</TagName><UserID>{4}</UserID></ArticleDTO>", artilceBody, headline, isfeatured, articlestub, userID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/article", Program.ROOT_URL);

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
        #endregion

        #region Update an  Article
        /// <summary>
        /// Update an article.
        /// </summary>
        public static void UpdateArticle()
        {
            try
            {
                string postData = "<ArticleDTO><ArticleID>36</ArticleID><Headline>Headline</Headline><UpdatedArticleBody>This artcle is updated from the WCF.</UpdatedArticleBody></ArticleDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/article", Program.ROOT_URL);

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
        #endregion

        #region Delete Article

        public static void DeleteArticle(int articleID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/article/{1}", Program.ROOT_URL, articleID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion
        
        #region Get Article

        public static void GetArticle(int articleID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/article/{1}", Program.ROOT_URL, articleID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Article Stub Availability
        /// <summary>
        /// Article Stub Availability
        /// </summary>
        public static void ArticleStubAvailability(int spaceID, string articleStub)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/availability?spaceID={1}&stub={2}", Program.ROOT_URL, spaceID, articleStub);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Set Article Status
        /// <summary>
        /// Set Article Status.
        /// </summary>
        public static void SetArticleStatus(int articleID,int statusID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/status?articleID={1}&statusID={2}", Program.ROOT_URL, articleID, statusID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                myRequest.ContentLength = 0;
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
        #endregion

        #region Get Related Article
        /// <summary>
        /// Get Related Article
        /// </summary>
        public static void GetRelatedArticle(int articleID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/relatedarticle/{1}", Program.ROOT_URL, articleID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Get All Articles
        /// <summary>
        /// Get All Articles
        /// </summary>
        public static void GetArticles()
        {
            try
            {
                string query = "?spaceID=0&userID=1&status=1";
                string serviceUrl = string.Format("{0}articleservice.svc/articles", Program.ROOT_URL);
                serviceUrl = string.Format("{0}{1}", serviceUrl, query);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        //#region Get All Articles
        ///// <summary>
        ///// Get All Articles
        ///// </summary>
        //public static void GetAllArticle()
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/articles", Program.ROOT_URL);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "GET";
        //        //add the API key
        //        myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);

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
        //#endregion

        #region Update Publish Status
        /// <summary>
        /// Update an article.
        /// </summary>
        public static void UpdatePublishStatus(int articleID)
        {
            try
            {
                //Add a new space using the REST API in Communifire

                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/publish/{1}", Program.ROOT_URL, articleID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                myRequest.ContentLength = 0;
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Update Article View COunt
        /// <summary>
        /// Update Article View COunt.
        /// </summary>
        public static void UpdateArticleViewCOunt(int articleID, long count)
        {
            try
            {
                //Add a new space using the REST API in Communifire

                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/viewcount?articleID={1}&count={2}", Program.ROOT_URL, articleID, count);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Get Tags Of Article
        /// <summary>
        /// Get Tags Of Article
        /// </summary>
        public static void GetTagsOfArticle(int articleID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/tags/{1}", Program.ROOT_URL,articleID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Delete Article Relation
        /// <summary>
        /// Adds the article.
        /// </summary>
        public static void DeleteArticleRelation(int relationID)
        {
            try
            {
                
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/articlerelation/{1}", Program.ROOT_URL, relationID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Associate Related Article
        /// <summary>
        /// Adds the article.
        /// </summary>
        public static void AssociateRelatedArticle(int articleID, int relationArticleID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/articlerelation/{1}/{2}", Program.ROOT_URL, articleID, relationArticleID);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Move To Next WorkFlow Step
        /// <summary>
        /// Move To Next WorkFlow Step
        /// </summary>
        public static void MoveToNextWorkFlowStep(int articleID, int workflowStepID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/workflowstep/{1}/{2}", Program.ROOT_URL, articleID, workflowStepID);
                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";
                myRequest.ContentLength = 0;
                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Get Article Statistics
        /// <summary>
        /// Adds the article statistics.
        /// </summary>
        public static void GetStatistics()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Get Articles Searched
        /// <summary>
        /// Get Articles Searched.
        /// </summary>
        public static void GetArticlesSearched(string searchText, string noOfArticles, string spaceID,string relatedArticleIDs)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/search?searchText={1}&noOfArticles={2}&spaceID={3}&relatedArticles={4}", Program.ROOT_URL, searchText, noOfArticles, spaceID, relatedArticleIDs);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion
        #endregion 

        #region Artcile Category Related

        #region Create Article Category
        /// <summary>
        /// Create Article Category
        /// </summary>
        public static void CreateArticleCategory()
        {
            try
            {
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category", Program.ROOT_URL);

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
        #endregion

        #region Update an  Article Category
        /// <summary>
        /// Update an article.
        /// </summary>
        public static void UpdateArticleCategory(int categoryID)
        {
            try
            {
                string postData = string.Format("<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryID>{0}</CategoryID><CategoryName>Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>", categoryID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category", Program.ROOT_URL);

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
        #endregion

        #region Delete Article Category
        /// <summary>
        /// Adds the article Category.
        /// </summary>
        public static void DeleteArticleCategory(int articleCategoryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category/{1}", Program.ROOT_URL, articleCategoryID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Get Article Category
        /// <summary>
        /// Get Article Category.
        /// </summary>
        public static void GetArticleCategory(int articleCategoryID)
        {
            try
            {

                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category/{1}", Program.ROOT_URL, articleCategoryID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                //var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
                //requestStream.Close();

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
        #endregion

        #region Get Article Categories
        /// <summary>
        /// Adds the article.
        /// </summary>
        public static void GetAllCategories(int categoryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category/categories?{1}", Program.ROOT_URL, categoryID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Category Stub Availability 
        /// <summary>
        /// Category Stub Availability.
        /// </summary>
        public static void CategoryStubAvailability(int spaceID, string stub)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articles/articles/category/availability?spaceID={1}&stub={2}", Program.ROOT_URL, spaceID, stub);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Get Article Categories Paged
        /// <summary>
        /// Adds the article.
        /// </summary>
        public static void GetAllCategories(string spaceID, string parentCategoryID, string statusID, string startPage, string pageLength)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/category/categories?spaceID={1}&parentCategoryID={2}&statusID={3}&startPage={4}&pageLength={5}", Program.ROOT_URL,  spaceID,  parentCategoryID,  statusID,  startPage,  pageLength);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion
        #endregion

        #region Article Comment
        #region Create Article Comment
        /// <summary>
        /// Create Article Comment
        /// </summary>
        public static void CreateArticleComment(int articleID)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = string.Format("<ArticleCommentDTO><ArticleID>2</ArticleID><CommentDate>2011-03-08T10:21:29.35</CommentDate><CommentText><p>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</p></CommentText><Headline>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus metus.</Headline><IPAddress>122.162.56.22</IPAddress><Name>admin</Name><StatusID>1</StatusID><TotalRecords>6</TotalRecords><UserEmail>test@email.com</UserEmail><UserID>1</UserID><UserName>admin</UserName><UserWebsite><UserWebsite/></ArticleCommentDTO>", articleID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comments", Program.ROOT_URL);

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
        #endregion

        #region Update an Article Comment
        /// <summary>
        /// Update an Article Comment
        /// </summary>
        public static void UpdateArticleComment(int commentID)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = string.Format("<ArticleCommentDTO><ArticleID>2</ArticleID><CommentDate>2011-03-08T10:21:29.35</CommentDate><CommentID>{0}</CommentID><CommentText><p>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</p></CommentText><Headline>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus metus.</Headline><IPAddress>122.162.56.22</IPAddress><Name>admin</Name><StatusID>1</StatusID><TotalRecords>6</TotalRecords><UserEmail>test@email.com</UserEmail><UserID>1</UserID><UserName>admin</UserName><UserWebsite><UserWebsite/></ArticleCommentDTO>", commentID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comments", Program.ROOT_URL);

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
        #endregion

        #region Delete Article Comment
        /// <summary>
        /// Adds the article Comment.
        /// </summary>
        public static void DeleteArticleComment(int commentID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comment/{1}", Program.ROOT_URL, commentID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Get Article Comment
        /// <summary>
        /// Get Article Comment.
        /// </summary>
        public static void GetArticleComment(int commentID)
        {
            try
            {

                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comment/{1}", Program.ROOT_URL, commentID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion

        #region Get Article Comments
        /// <summary>
        /// Adds the article comments.
        /// </summary>
        public static void GetComments(string spaceID, string articleID, string statusID, string userID, string sortColumn, string sortOrder, string startPage, string pageLength)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comments/commentslist?spaceID={1}&articleID={2}&statusID={3}&userID={4}&sortColumn={5}&sortOrder={6}&startPage={7}&pageLength={8}", Program.ROOT_URL,  spaceID,  articleID,  statusID,  userID,  sortColumn,  sortOrder,  startPage,  pageLength);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "GET";
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
        #endregion

        #region Set Comment Status
        /// <summary>
        /// Set Comment Status
        /// </summary>
        public static void SetCommentStatus(int commentID, int statusID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/articles/comment/status?commentID={1}&statusID={2}", Program.ROOT_URL, commentID, statusID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "PUT";
                myRequest.ContentLength = 0;
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
        #endregion

        #endregion

        #region Article License
        #region Create Article License
        /// <summary>
        /// Create Article License
        /// </summary>
        public static void CreateArticleLicense()
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = string.Format("<LicenseDTO><LincenseText>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</LincenseText><Name>REST API Test License</Name></LicenseDTO>");
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/comments", Program.ROOT_URL);

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
        #endregion

        #region Update an Article License
        /// <summary>
        /// Update an Article License
        /// </summary>
        public static void UpdateArticleLicense(int licenseID)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = string.Format("<LicenseDTO><LincenseID>{0}</<LincenseID><LincenseText>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</LincenseText><Name>Update: REST API Test License</Name></LicenseDTO>", licenseID);
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/license", Program.ROOT_URL);

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
        #endregion

        #region Delete Article license
        /// <summary>
        /// Adds the article license.
        /// </summary>
        public static void DeleteArticleLicense(int licenseID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}articleservice.svc/articles/license?licenseID={1}", Program.ROOT_URL, licenseID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
                //set the content header type. Note: use "application/json" for JSON
                myRequest.ContentType = "application/xml";

                //add the API key
                myRequest.Headers.Add("Rest-Api-Key", Program.API_KEY);
                //add the data to be posted in the request stream
                var requestStream = myRequest.GetRequestStream();
                //requestStream.Write(data, 0, data.Length);
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
        #endregion
        #endregion
    }
}
