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
        public static readonly string ROOT_URL = "http://cftesting.com/services/";//http://localhost:499/
        public static readonly string API_KEY = "YWRtaW46NzU3MTk2MWUtMmJkOC00Y2VhLWI0YTktNmMwZjdjZTZhMTI1";

        //public static readonly string ROOT_URL = "http://cftesting.com//services/";
        //public static readonly string API_KEY = "YWRtaW46YzdkZmE4MDgtNTAxNi00YjU5LTk1ZGItYzA4ZWU4Zjk5Njgz";

        static void Main(string[] args)
        {
            UserServiceSample.AddUser("email@yy.com","jrambo", "John", "Rambo", "test");

            CommonSample.GetGenericContent("3", null, null, null, null, null,null, null, null, 1, 1, null, null, 1, 20);
            Console.ReadLine();
        }
    }//end class
}//end namespace
