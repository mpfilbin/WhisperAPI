using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Whisper.API.Utilities
{
    public static class PearsonApiUtilities
    {
        public static string GetOauthAccessToken(string username, string password)
        {
            const string grantType = "password";
            const string clientID = "814c9ce7-664a-412f-a830-ff96269b0613";
            const string clientString = "sullyu";
            const string url = "https://m-api.ecollege.com/token";

            // Create the request data
            var data = new StringBuilder();
            data.Append("grant_type=" + Uri.EscapeDataString(grantType));
            data.Append("&client_id=" + Uri.EscapeDataString(clientID));
            data.Append("&username=" + Uri.EscapeDataString(clientString + "\\" + username));
            data.Append("&password=" + Uri.EscapeDataString(password));

            // Create a byte array of the data to be sent
            byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString());

            // Setup the Request
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            // Write data
            Stream postStream = request.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            // Send Request & Get Response
            var response = (HttpWebResponse)request.GetResponse();

            string accessToken;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                // Get the Response Stream
                string json = reader.ReadLine();

                // Retrieve and Return the Access Token
                var ser = new JavaScriptSerializer();
                var x = (Dictionary<string, object>)ser.DeserializeObject(json);
                accessToken = x["access_token"].ToString();
            }

            return accessToken;
        }

        public static string XAuthApiCall(string token, string url)
        {
            // Build the X-Authorization request header
            string xauth = String.Format("X-Authorization: Access_Token access_token={0}", token);

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add(xauth);

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return json;
                    }
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
                        return String.Format("The server returned '{0}' with the status code '{1} ({2:d})'.",
                            err.StatusDescription, err.StatusCode, err.StatusCode);
                    }
                }
                return e.Message;
            }


        }

        public static string GetUser(string token, string userID)
        {
            var url = String.Format("https://m-api.ecollege.com/users/{0}", userID);

            var userJson = XAuthApiCall(token, url);
            return userJson;
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}