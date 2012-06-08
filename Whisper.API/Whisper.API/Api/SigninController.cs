using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Whisper.API.Models;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class SigninController : ApiController
    {
        // POST /api/signin
        [AllowCrossSiteJson]
        public string Post(string username, string password)
        {
            var test = Request.Content.Headers.ToString();
            var token = PearsonApiUtilities.GetOauthAccessToken(username, password);

            string[] tokenParts = token.Split('|');

            var userID = tokenParts[2];
            var url = string.Format("https://m-api.ecollege.com/users/{0}", userID);

            var userJson = PearsonApiUtilities.XAuthApiCall(token, url);
            //var result = StudentUtilities.GetStudentPoco("User0001");

            //result.UserName = username; //for testing purposes only...
           HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            return userJson;
        }

    }

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}
