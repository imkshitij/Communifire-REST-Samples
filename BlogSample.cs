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
    public class BlogSample
    {
        //#region Blog Related

        //#region CRUD Blog Methods

        //public static void CreateBlog()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<BlogDTO><BlogName>Blog Name</BlogName><Intro>Blog Intro</Intro><UserID>1</UserID></BlogDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs", Program.ROOT_URL);

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
        //    Console.Read();
        //}

        //public static void UpdateBlog()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<BlogDTO><BlogName>Blog Name</BlogName><Intro>Blog Intro</Intro><UserID>1</UserID></BlogDTO><BlogID>36</BlogID";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs", Program.ROOT_URL);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}

        //public static void DeleteBlog(int blogID)
        //{
        //    try
        //    {
        //        //Deletes a community user using the REST API based on user ID
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/{1}", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "DELETE";
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
        //    Console.Read();
        //}

        //public static void AssignBlogAuthor(int blogID, int userID)
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/assignauthor?userID={1}&blogID={2}", Program.ROOT_URL, 1, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}

        //public static void DeleteBlogAuthors(int blogID)
        //{
        //    try
        //    {
        //        //Deletes a community user using the REST API based on user ID
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/deleteauthor/{1}", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "DELETE";
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
        //    Console.Read();
        //}

        //public static void SetBlogWorkflowStatus(bool status, int workflowID)
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/workflowstatus?status={1}&workflowID={2}", Program.ROOT_URL, 1, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}
        //#endregion

        //#region Get Methods

        //public static void GetBlog(int blogID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/user?userName={1}&blogID={2}", Program.ROOT_URL, 1, 1);

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
        //    Console.Read();
        //}
        //public static void GetBlog(string userName)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void GetBlogsByUserID(int userID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void GetBlogIDs(int userID, bool? isActive)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void GetAllBlogs()
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}
        //public static void GetBlogs(bool? isActive, int? categoryID, int? userID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}

        //public static void GetTopNBlogContributors(int spaceID, int year, int month, int N)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/topcontributors?spaceID={1}&year={2}&month={3}&noofcontributers={4}", Program.ROOT_URL, 1, 1, 1, 1);

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
        //    Console.Read();
        //}

        //public static void GetAllBlogs(int categoryID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void GetBlogAuthors(int blogID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/author/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}

        //#endregion

        //#endregion Blog Related

        #region Blog Entry Related

        #region CRUD Blog Entry Methods
        public static void CreateBlogEntry()
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<BlogEntryDTO><BlogID>1</BlogID><CategoryID>1</CategoryID><EntryText>OO HHTest Blog Entry</EntryText><EntryTitle>OO Test Blog Entry</EntryTitle></BlogEntryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry", Program.ROOT_URL);

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
            Console.Read();
        }
        public static void UpdateBlogEntry()
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<BlogEntryDTO><BlogEntryID>168</BlogEntryID><EntryTitle>Mahila Delhi Policia</EntryTitle><UpdatedEntryText>Mahila police sucks</UpdatedEntryText></BlogEntryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry", Program.ROOT_URL);

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
            Console.Read();
        }
        public static void DeleteBlogEntry(int blogEntryID)
        {
            try
            {
                //Deletes a community user using the REST API based on user ID
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/{blogEntryID}", Program.ROOT_URL, 1);

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
            Console.Read();
        }
        #endregion

        #region Get Methods
        public static void GetBlogEntry(int blogEntryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/{1}", Program.ROOT_URL, 1);

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
            Console.Read();
        }
        public static void GetBlogStatistics(DateTime currentDateTime)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/statistics", Program.ROOT_URL);

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
            Console.Read();
        }
        public static void GetBlogEntries()
        {
            try
            {
                //set the RESTful URL
                //string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries?spaceID={1}&userID={2}&blogID={3}&entitystatus={4}&pendingapproval={5}&daterange={6}&loadingtype={7}&datepublishedtime={8}&sortcolumn={9}&sortOrder={10}&startpage={11}&pageLength={12}", Program.ROOT_URL, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries", Program.ROOT_URL);

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
                                string xmlResult = resultsXml.GetElementsByTagName("ResponseData")[0].InnerXml;
                                xmlResult = string.Format("<ResponseData>{0}</ResponseData>", xmlResult);
                                XmlReader xmlReader = XmlReader.Create(new StringReader(xmlResult));
                                //xmlReader.Read();
                                XmlRootAttribute xRoot = new XmlRootAttribute
                                {
                                    ElementName = "ResponseData",
                                    IsNullable = true
                                };
                                var serializer = new XmlSerializer(typeof(Collection<BlogEntryDTO>), xRoot);
                                var entries = (Collection<BlogEntryDTO>)serializer.Deserialize(xmlReader);
                                foreach (BlogEntryDTO entry in entries)
                                {
                                    Console.Write(entry.BlogEntryID);
                                    Console.Write(Environment.NewLine);

                                }
                                Console.ReadLine();
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
            Console.Read();
        }

        public static void GetArchiveMonthList(int spaceID, int? userID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries/archive/{1}/{2}", Program.ROOT_URL, 1, 1);

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
            Console.Read();
        }
        public static void GetArchivedEntries(int spaceID, int? userID, int year, int month, int startPage, int pageLength)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries/archive?spaceID={1}&userID={2}&year={3}&month={4}&startpage={5}&pagelength={6}", Program.ROOT_URL, 1, 1, 1, 1, 1, 1);

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
            Console.Read();
        }
        #endregion

        public static void GetQueuedWorkflowBlogEntries(int roleID, int startPage, int pageLength)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries/workflow?spaceID={1}&roleID={2}&startpage={3}&pagelength={4}", Program.ROOT_URL, 1, 1, 1, 1);

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
            Console.Read();
        }

        public static void GetQueuedWorkflowBlogEntries(int spaceID, int roleID, int startPage, int pageLength)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogsentries/workflow?spaceID={1}&roleID={2}&startpage={3}&pagelength={4}", Program.ROOT_URL, 1, 1, 1, 1);

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
            Console.Read();
        }
        public static void SetBlogEntryStatus()
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
            Console.Read();
        }
        public static void ReplaceCategory(int oldCategoryID, int newCategoryID)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/replace", Program.ROOT_URL);

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
            Console.Read();
        }
        public static void CheckStubAvailability(int spaceID, string stub)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/availability?spaceID={1}&stub={2}", Program.ROOT_URL, 1, 1);

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
            Console.Read();
        }
        public static void UpdatePublishStatus()
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/publishstatus/{1}", Program.ROOT_URL, 1);

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
            Console.Read();
        }
        public static void UpdateBlogEntryViewCount(int blogEntryID, long viewCount)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogs/blogentry/viewcount?blogEntryID={1}&viewCount={2}", Program.ROOT_URL, 1, 1);

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
            Console.Read();
        }
        public static void MoveToNextWorkFlowStep(int articleID, int workflowStepID)
        {
            try
            {
                //Add a new space using the REST API in Communifire
                //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
                string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/workflow?blogEntryID={1}&workflowStepID={2}", Program.ROOT_URL, 1, 1);

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
            Console.Read();
        }
        public static void GetTags(int blogEntryID)
        {
            try
            {
                //set the RESTful URL
                string serviceUrl = string.Format("{0}blogservice.svc/blogs/blogentry/tags/{1}", Program.ROOT_URL, 1);

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
            Console.Read();
        }
        #endregion Blog Entry Related

        //#region Blog Category Related

        //#region CRUD Blog Category
        //public static void CreateBlogCategory()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category", Program.ROOT_URL);

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
        //    Console.Read();
        //}

        //public static void UpdateBlogCategory()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><CategoryID>4</CategoryID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category", Program.ROOT_URL);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}

        //public static void AssignDeletedCategory(int deletedCategoryID, int newCategoryID)
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/assigncategory", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}
        //public static void DeleteBlogCategory(int categoryID)
        //{
        //    try
        //    {
        //        //Deletes a community user using the REST API based on user ID
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/{1}", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "DELETE";
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
        //    Console.Read();
        //}
        //#endregion

        //#region Get Methods
        //public static void GetCategory(int categoryID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}
        //public static void GetCategoryByBlogID(int blogID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/blog/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}
        //public static void GetCategoryIDByUserID(int userID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/user/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}
        //public static void GetAllBlogCategories()
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}articleservice.svc/articles/statistics", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void GetBlogCategories(int startPage, int pageLength)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/category/categories?startpage={1}&pagelength={2}", Program.ROOT_URL, 1, 15);

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
        //    Console.Read();
        //}
        //#endregion

        //#endregion Blog Category Related

        //#region Blog Comment related methods

        //#region CRUD Blog Comment
        //public static void CreateBlogComment()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void UpdateBlogComment()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment", Program.ROOT_URL);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}
        //public static void DeleteBlogComment(int blogCommentID)
        //{
        //    try
        //    {
        //        //Deletes a community user using the REST API based on user ID
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment/{1}", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "DELETE";
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
        //    Console.Read();
        //}
        //#endregion

        //#region Get Methods
        //public static void GetComment(int blogCommentID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment/{1}", Program.ROOT_URL, 1);

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
        //    Console.Read();
        //}
        //public static void GetBlogComments()
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment/list?spaceID={1}&userID={2}&blogEntryID={3}&status={4}&sortBlogCommentColumn={5}&sortOrderType={6}&startPage={7}&pageLength={8}", Program.ROOT_URL, 1, 1, 1, 1, 1, 1, 1, 1);

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
        //    Console.Read();
        //}
        //public static void SetCommentStatus(int commentID, int status)
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/comment/commentstatus??commentID={1}&status={2}", Program.ROOT_URL, 1, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "PUT";
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
        //    Console.Read();
        //}
        //#endregion

        //#endregion//end blog Comment related methods

        //#region Blog Entry Vote related methods

        //#region CRUD Blog Entry vote
        //public static void CreateBlogEntryVote()
        //{
        //    try
        //    {
        //        //Add a new space using the REST API in Communifire
        //        //create a new space. Note: Make sure the data is in alphabetical format because serialization is done alphabetically 
        //        string postData = "<CategoryDTO><ActiveStatus>1</ActiveStatus><CategoryDescription>test rest api article category</CategoryDescription><CategoryName>Default Rest API Article Category</CategoryName><Headline>Default Rest API Article Category</Headline><MetaDescription>article</MetaDescription>Default Rest API Article Category<MetaKeywords>test article</MetaKeywords><MetaTitle>Article Meta Title</MetaTitle><ParentID>0</ParentID><ParentName></ParentName><SEOName>Default-Rest-API-Article-Category</SEOName><SpaceID>0</SpaceID></CategoryDTO>";
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/vote", Program.ROOT_URL);

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
        //    Console.Read();
        //}
        //public static void DeleteBlogEntryVote(int voteID)
        //{
        //    try
        //    {
        //        //Deletes a community user using the REST API based on user ID
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/vote/{voteID}", Program.ROOT_URL, 1);

        //        //create a new HttpRequest
        //        var myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
        //        myRequest.Method = "DELETE";
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
        //    Console.Read();
        //}
        //#endregion

        //#region GET Methods
        //public static void GetVote(int userID, int blogEntryID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/vote?userID={1}&blogEntryID={2}", Program.ROOT_URL, 1, 1);

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
        //    Console.Read();
        //}
        //#endregion

        //public static void CheckIfAlreadyVoted(int userID, int blogEntryID)
        //{
        //    try
        //    {
        //        //set the RESTful URL
        //        string serviceUrl = string.Format("{0}blogservice.svc/blogs/blog/vote/alreadyvoted?userID={1}&blogEntryID={2}", Program.ROOT_URL, 1, 1);

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
        //    Console.Read();
        //}
        //#endregion Vote related methods
    }
    
    public class BlogEntryDTO
    {


        /// <summary>
        /// Gets or sets the blog ID of the blog entry.
        /// </summary>
        /// <value>The blog ID of the blog entry.</value>
        public System.Int32 BlogID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user ID of the user who created the blog entry.
        /// </summary>
        /// <value>The user ID of the user who created the blog entry.</value>
        public System.Int32 UserID
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the media server ID.
        /// </summary>
        /// <value>The media server ID.</value>
        public int MediaServerID
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        /// <value>The category ID.</value>
        public System.Int32 CategoryID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the workflow ID.
        /// </summary>
        /// <value>The workflow ID.</value>

        public System.Int32 WorkflowID
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the current workflow step ID.
        /// </summary>
        /// <value>The current workflow step ID.</value>
        public System.Int32 CurrentWorkflowStepID
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets a value of the StatusID of the post.
        /// </summary>
        public System.Int32 StatusID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether pending approval.
        /// </summary>
        public System.Boolean PendingApproval
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is latest.
        /// </summary>
        public System.Boolean IsLatest
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets IsFeatured.
        /// </summary>
        public System.Boolean IsFeatured
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value of is private space.
        /// </summary>
        /// <value>true if this instance is private space,else false.</value>
        public System.Boolean IsPrivateSpace
        {
            get;
            set;
        }


        /// <summary>
        ///Gets or sets a value of entry title.
        /// </summary>
        /// <value>The entry title.</value>
        public System.String EntryTitle
        {
            get;
            set;

        }

        /// <summary>
        ///Gets or sets a value of space name.
        /// </summary>
        /// <value>The name of the space.</value>
        public System.String SpaceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of space ID.
        /// </summary>
        /// <value>The space ID of space.</value>
        public System.Int32 SpaceID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The value of month.</value>
        public int Month
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value by month.
        /// </summary>
        /// <value>The blog entry by month.</value>
        public string ByMonth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of year.
        /// </summary>
        /// <value>The value of year.</value>
        public System.Int32 Year
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the blog count.
        /// </summary>
        /// <value>The blog count.</value>
        public System.Int32 BlogCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        /// <value>The name of the category.</value>
        public System.String CategoryName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the  value of entry intro.
        /// </summary>
        /// <value>The entry intro.</value>
        public System.String EntryIntro
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the entry text.
        /// </summary>
        /// <value>true if set blog entry status successful,else false.</value>
        public System.String EntryText { get; set; }

        /// <summary>
        /// Gets or sets updated entry text.
        /// </summary>
        /// <value>The updated entry text.</value>
        public string UpdatedEntryText { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The value of created date.</value>
        public DateTime DateCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>The date modified.</value>
        public DateTime? DateModified
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date published.
        /// </summary>
        /// <value>The date when the blog entry was published.</value>
        public DateTime? DatePublished
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        /// <value>The name of the user.</value>
        public System.String UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets avatar Path.
        /// </summary>
        /// <value>The avatar path.</value>
        public System.String AvatarPath
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets title  of image.
        /// </summary>
        /// <value>The title image path.</value>
        public String TitleImage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the blog name.
        /// </summary>
        /// <value>The name of the blog.</value>
        public System.String BlogName { get; set; }

        /// <summary>
        ///Gets or sets introduction.
        /// </summary>
        /// <value>The introduction.</value>
        public System.String Introduction { get; set; }

        /// <summary>
        /// Gets or sets blog entry ID.
        /// </summary>
        /// <value>The blog entry ID.</value>
        public System.Int32 BlogEntryID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment count.
        /// </summary>
        /// <value>The comment count.</value>
        public System.Int32 CommentCount
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets the anonymous comments.
        /// </summary>
        /// <value>true if anonymous comments,else false.</value>
        public System.Boolean AnonymousComments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meta title.
        /// </summary>
        /// <value>The meta title.</value>
        public System.String MetaTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        /// <value>The meta description.</value>
        public System.String MetaDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meta keywords.
        /// </summary>
        /// <value>The meta keywords.</value>
        public System.String MetaKeywords
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the excerpt.
        /// </summary>
        /// <value>The excerpt.</value>
        public System.String Excerpt { get; set; }

        /// <summary>
        /// Gets or sets the trackback url.
        /// </summary>
        /// <value>The trackback url.</value>
        public System.String TrackbackURL
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets the Stub.
        /// </summary>
        /// <value>The stub to be checked.</value>
        public System.String Stub
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the views of blogs.
        /// </summary>
        /// <value>The views of blogs.</value>
        public System.Int32? Views
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets the tag name.
        /// </summary>
        /// <value>The name of the tag.</value>
        public System.String TagName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tag ID.
        /// </summary>
        /// <value>The tag ID.</value>
        public System.Int32 TagId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the media server root url.
        /// </summary>
        /// <value>The media server root url.</value>
        public string MediaServerRootURL { get; set; }

        /// <summary>
        /// Gets or sets the blog entry media server root url.
        /// </summary>
        /// <value>The media server root url.</value>
        public System.String BlogEntryMediaServerRootURL
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of author.
        /// </summary>
        /// <value> first name of author.</value>
        public System.String FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name of author.
        /// </summary>
        /// <value>last name of author.</value>
        public System.String LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the email of user.
        /// </summary>
        /// <value>Email ID of user.</value>
        public System.String UserEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the user profile url.
        /// </summary>
        /// <value>The user profile url.</value>
        public string UserProfileURL { get; set; }

        /// <summary>
        ///  Gets or sets the display name of the user.
        /// </summary>
        /// <value> The display name of the user.</value>
        public string UserDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the user avatar full url.
        /// </summary>
        /// <value>The user avatar full url.</value>
        public string UserAvatarFullUrl { get; set; }

        /// <summary>
        /// Gets or sets the span date time. 
        /// </summary>
        /// <value>The date time span.</value>
        public string DateTimeSpan { get; set; }

        /// <summary>
        /// Gets or sets the blog url.
        /// </summary>
        /// <value> The url of blog.</value>
        public string BlogURL { get; set; }

        /// <summary>
        /// Gets or sets summary.
        /// </summary>
        /// <value> The summary.</value>

        public string Summary
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is published from draft mode.
        /// </summary>
        /// <value> true if this instance is published from draft mode else,false.</value>
        public bool IsPublishedFromDraftMode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is published from delayed publishing mode.
        /// </summary>
        /// <value>true if this instance is published from delayed publishing mode,else false.</value>
        public bool IsPublishedFromDelayedPublishingMode { get; set; }

        /// <summary>
        /// Gets or sets the updated by user ID.
        /// </summary>
        /// <value>The updated by user ID.</value>
        public int UpdatedByUserID { get; set; }

    }


}
