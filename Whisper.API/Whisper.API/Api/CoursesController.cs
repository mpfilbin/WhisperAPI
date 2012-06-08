using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class CoursesController : ApiController
    {

        public List<StudentCourses.Course> Student(string token, string id)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            var decodedToken = PearsonApiUtilities.DecodeFrom64(token);

            var meCoursesJson = PearsonApiUtilities.XAuthApiCall(decodedToken, "http://m-api.ecollege.com/me/courses");
            var meCourses = new JavaScriptSerializer().Deserialize<MeCourses>(meCoursesJson);

            var result = new List<StudentCourses.Course>();

            foreach (var course in meCourses.courses)
            {
                foreach (var link in course.links)
                {
                    var courseDetailJson = PearsonApiUtilities.XAuthApiCall(decodedToken, link.href);
                    var courseDetail = new JavaScriptSerializer().Deserialize<StudentCourses>(courseDetailJson);
                    result.Add(courseDetail.courses[0]);
                }
            }

            return result;
        }

        public class MeCourses
        {
            public List<Courses> courses { get; set; }

            public class Courses
            {
                public List<Link> links { get; set; }
            }

            public class Link
            {
                public string href { get; set; }
            }
        }

        public class StudentCourses
        {
            public List<Course> courses { get; set; }

            public class Course
            {
                public string id { get; set; }
                public string displayCourseCode { get; set; }
                public string title { get; set; }
            }
        }

    }
}
