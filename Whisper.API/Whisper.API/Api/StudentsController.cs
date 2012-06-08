using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Whisper.API.Models;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class StudentsController : ApiController
    {
        // GET /api/students/5
        public string GetStudent(string token, string id)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            var decodedToken = PearsonApiUtilities.DecodeFrom64(token);
            return PearsonApiUtilities.GetUser(decodedToken, id);
        }

        // POST /api/students
        //public string Post(string token, string id)
        //{
        //    return PearsonApiUtilities.GetUser(token, id);
        //}


    }
}
