using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Whisper.API.Models;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class SigninController : ApiController
    {
        // POST /api/signin
        //[AllowCrossSiteJson]
        public SigninResult Authenticate(string username, string password)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            var test = Request.Content.Headers.ToString();
            var token = PearsonApiUtilities.GetOauthAccessToken(username, password);
            //return token;

            string[] tokenParts = token.Split('|');

            var userID = tokenParts[2];

            var userJson = PearsonApiUtilities.GetUser(token, userID);

            var result = new SigninResult()
                             {
                                 EncodedAuthToken = PearsonApiUtilities.EncodeTo64(token),
                                 UserId = userID,
                                 User = userJson
                             };
            return result;
        }
    }

    public class SigninResult
    {
        public string EncodedAuthToken { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
    }

    //public class AllowCrossSiteJsonAttribute : System.Web.Http.Filters.ActionFilterAttribute
    //{
    //    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        actionExecutedContext.ActionContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //        base.OnActionExecuted(actionExecutedContext);
    //    }
    //}
}
