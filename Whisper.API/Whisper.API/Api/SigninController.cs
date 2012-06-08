using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Whisper.API.Models;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class SigninController : ApiController
    {
        // POST /api/signin
        public string Post(string username, string password)
        {
            var test = Request.Content.Headers.ToString();
            var token = PearsonApiUtilities.GetOauthAccessToken(username, password);

            //var result = StudentUtilities.GetStudentPoco("User0001");

            //result.UserName = username; //for testing purposes only...

            return token;
        }

    }
}
