#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Communifire.RestApiSamples
{
    class VideoSample
    {
        #region Video Category
        public void CreateCategory()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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
        public void GetCategory(int categoryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category/{1}", Program.ROOT_URL, categoryID);

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

        public void UpdateCategory()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void GetCategories()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category/categorylist?spaceID={1}&parentCategoryID={2}&isActive={3}&sortColumn={4}&sortOrder={5}&startPage={6}&pageLength={7}", Program.ROOT_URL, 1, 1,1,1,1,1,1);

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
        
        public void AssignDeletedCategory(int deletedCategoryID, int newCategoryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category/{1}/{2}", Program.ROOT_URL,deletedCategoryID,newCategoryID);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void DeleteCategory(int categoryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/category/{1}", Program.ROOT_URL, categoryID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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

        #region Video
        public void CreateVideo()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void GetVideo(int videoID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/{1}", Program.ROOT_URL, videoID);

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

        public void GetVideos()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/videoslist?userID={1}&categoryID={2}&spaceID={3}&status={4}&sortColumn={5}&sortOrder={6}&startPage={7}&pageLength={8}", Program.ROOT_URL, 1, 1,1,1,1,1,1,1);

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

        public void UpdateVideo()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void CheckStubAvailability(int spaceID, string stubName)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/availability?spaceID={1}&stubName={2}", Program.ROOT_URL,spaceID,stubName);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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
       
        public void DeleteVideo(int videoID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/{1}", Program.ROOT_URL, videoID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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

        public void SetVideoStatus(int videoID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/videostatus/{1}/{2}", Program.ROOT_URL,videoID,1);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void UpdateVideoViewCount(int videoID, long viewCount)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/viewcount/{1}?viewCount={2}", Program.ROOT_URL,videoID,viewCount);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        #region Video Comment
        public void CreateComment()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/comment", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        public void DeleteComment(int commentID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/comment/{1}", Program.ROOT_URL, commentID);

                //create a new HttpRequest
                var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                myRequest.Method = "DELETE";
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

        public void GetComment(int commentID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/comment/{1}", Program.ROOT_URL, commentID);

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

        public void GetComments()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/comment/commentlist?spaceID={1}&videoID={2}&userID={3}&status={4}&sortColumn={5}&sortOrder={6}&startPage={7}&pageLength={8}", Program.ROOT_URL, 1, 1,1,1,1,1,1,1);

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

        public void SetCommentStatus(int commentID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}/videoservice.svc/vidoes/video/comment/{1}/{2}", Program.ROOT_URL,commentID,1);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        #region Video Rate related methods

        #region CRUD Video Rate

        public void RateVideo()
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/vote", Program.ROOT_URL);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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

        #region GET Methods

        public void GetVote(int userID, int videoID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/vote/{1}/{2}", Program.ROOT_URL, userID, videoID);

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

        public void CheckIfAlreadyVoted(int userID, int videoID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}videoservice.svc/vidoes/video/vote/voted/{1}/{2}", Program.ROOT_URL,userID,videoID);

                string postData = "<PhotoDTO><AlbumCover>false</AlbumCover><AlbumCoverPath></AlbumCoverPath><AlbumID>12</AlbumID><AlbumName>Test Album</AlbumName><AvatarPath></AvatarPath><Caption>test caption</Caption><CurrentWorkFlowStepID>0</CurrentWorkFlowStepID><DateCreated>2011-01-01T00:00:00</DateCreated><Height>0</Height><IsFeatured>false</IsFeatured><IsVisiblePublicly>true</IsVisiblePublicly><IsVisibleToFriends>false</IsVisibleToFriends><MediaServerID>1</MediaServerID><MediaServerRootURL></MediaServerRootURL><PhotoPath></PhotoPath><PhotoThumbNailImageSrc></PhotoThumbNailImageSrc><PhotoTitle>test title</PhotoTitle><PhotoURL>photo url</PhotoURL><Status>1</Status><TagName>test tag</TagName><ThumbImagePath></ThumbImagePath><TotalSize>10</TotalSize><UserID>1</UserID><Width>0</Width><WorkFlowID>1</WorkFlowID></PhotoDTO>";
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
        #endregion Vote related methods
    }
}
