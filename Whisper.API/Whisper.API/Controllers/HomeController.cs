using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Whisper.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Message = "Api test page.";

            return View();
        }

        public ActionResult OAuthTest()
        {

            string username = "jhNXTprof";
            string password = "jhNXTprof";

            // Setup the variables necessary to make the Request 
            string grantType = "password";
            string clientID = "814c9ce7-664a-412f-a830-ff96269b0613";
            string clientString = "sullyu";

            string url = "https://m-api.ecollege.com/token";
            HttpWebResponse response = null;

            try
            {
                // Create the data to send
                StringBuilder data = new StringBuilder();
                data.Append("grant_type=" + Uri.EscapeDataString(grantType));
                data.Append("&client_id=" + Uri.EscapeDataString(clientID));
                data.Append("&username=" + Uri.EscapeDataString(clientString + "\\" + username));
                data.Append("&password=" + Uri.EscapeDataString(password));

                // Create a byte array of the data to be sent
                byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString());

                // Setup the Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                // Write data
                Stream postStream = request.GetRequestStream();
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();

                // Send Request & Get Response
                response = (HttpWebResponse)request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // Get the Response Stream
                    string json = reader.ReadLine();
                    Console.WriteLine(json);

                    // Retrieve and Return the Access Token
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    Dictionary<string, object> x = (Dictionary<string, object>)ser.DeserializeObject(json);
                    string accessToken = x["access_token"].ToString();

                    ViewBag.OAuthResult = accessToken;

                    ViewBag.MeCoursesResult = XAuthHeaderTest(accessToken);
                }
            }
            catch (WebException e)
            {
                // This exception will be raised if the server didn't return 200 - OK
                // Retrieve more information about the error
                if (e.Response != null)
                {
                    using (HttpWebResponse err = (HttpWebResponse)e.Response)
                    {
                        ViewBag.Result = string.Format ("The server returned '{0}' with the status code '{1} ({2:d})'.",
                            err.StatusDescription, err.StatusCode, err.StatusCode);
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }


            return View();

        }

        public string XAuthHeaderTest(string token)
        {
            // Build the X-Authorization request header
            string xauth = String.Format("X-Authorization: Access_Token access_token={0}", token);

            HttpWebResponse response = null;

            try
            {
                // Setup the Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://m-api.ecollege.com/me/courses");
                request.Method = "GET";
                request.Headers.Add(xauth);

                // Set the request body if making a POST or PUT request
                //if (httpMethod == "POST" || httpMethod == "PUT")
                //{
                //    byte[] dataArray = Encoding.UTF8.GetBytes(body);
                //    request.ContentLength = dataArray.Length;

                //    Stream requestStream = request.GetRequestStream();
                //    requestStream.Write(dataArray, 0, dataArray.Length);
                //    requestStream.Close();
                //}

                // Send Request & Get Response
                 response = (HttpWebResponse)request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // Get the response stream and write to console
                    string json = reader.ReadToEnd();
                    return json;
                }
            }
            catch (WebException e)
            {
                // This exception will be raised if the server didn't return 200 - OK
                // Retrieve more information about the error
                if (e.Response != null)
                {
                    using (HttpWebResponse err = (HttpWebResponse)e.Response)
                    {
                        return string.Format("The server returned '{0}' with the status code '{1} ({2:d})'.",
                            err.StatusDescription, err.StatusCode, err.StatusCode);
                    }
                }
                return e.Message;
            }
            finally
            {
                if (response != null) { response.Close(); }
            }
 
        }
    }
}
