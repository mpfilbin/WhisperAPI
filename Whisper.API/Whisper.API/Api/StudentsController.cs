using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Whisper.API.Models;

namespace Whisper.API.Controllers
{
    public class StudentsController : ApiController
    {
        // GET /api/students/5
        public StudentPoco Get(string id)
        {
            return StudentUtilities.GetStudentPoco(id);
        }

        // POST /api/students
        public StudentPoco Post(string id)
        {
            return StudentUtilities.GetStudentPoco(id);
        }


    }
}
