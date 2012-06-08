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
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Technology & Team...";

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

            const string username = "jhNXTprof";
            const string password = "jhNXTprof";

            var accessToken = PearsonApiUtilities.GetOauthAccessToken(username, password);

            string[] tokenParts = accessToken.Split('|');

            ViewBag.UserId = tokenParts[2];

            ViewBag.AccessToken = PearsonApiUtilities.EncodeTo64(accessToken);

            return View();
        }


        public ActionResult OAuthTest()
        {
            const string username = "jhNXTprof";
            const string password = "jhNXTprof";

            var accessToken = PearsonApiUtilities.GetOauthAccessToken(username, password);

            ViewBag.OAuthResult = accessToken;
            ViewBag.MeCoursesResult = PearsonApiUtilities.XAuthApiCall(accessToken, "http://m-api.ecollege.com/me/courses");
            ViewBag.CourseDetails = PearsonApiUtilities.XAuthApiCall(accessToken, "https://m-api.ecollege.com/courses/3312999");
            ViewBag.Students = PearsonApiUtilities.XAuthApiCall(accessToken, "https://m-api.ecollege.com/courses/3312999/students");
            ViewBag.User = PearsonApiUtilities.XAuthApiCall(accessToken, "https://m-api.ecollege.com/users/4433390");

            return View();
        }



    }
}
