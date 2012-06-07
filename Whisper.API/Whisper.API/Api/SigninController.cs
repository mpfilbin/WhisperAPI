using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Whisper.API.Models;

namespace Whisper.API.Controllers
{
    public class SigninController : ApiController
    {
        // POST /api/signin
        public StudentPoco Post(string username, string password)
        {
            var result = StudentUtilities.GetStudentPoco("User0001");

            result.UserName = username; //for testing purposes only...

            return result;
        }

    }
}
