using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class CoursesController : ApiController
    {

        public List<Course> Student(string token, string id)
        {
            var decodedToken = PearsonApiUtilities.DecodeFrom64(token);

            var meCoursesResult = PearsonApiUtilities.XAuthApiCall(decodedToken, "http://m-api.ecollege.com/me/courses");

            var result = new JavaScriptSerializer().Deserialize<CourseResults>(meCoursesResult);

            var courses = new List<Course>();
            foreach (var course in result.courses)
            {
                foreach (var link in course.links)
                {
                    var courseDetailJson = PearsonApiUtilities.XAuthApiCall(decodedToken, link.href);

                    var courseDetail = new JavaScriptSerializer().Deserialize<CourseDetailResults>(courseDetailJson);
                    courses.Add(courseDetail.courses[0]);                  
                }
            }

            return courses;
        }


        public class CourseResults
        {
            public List<Courses> courses { get; set; } 
        }

        public class Courses 
        {
            public List<Link> links { get; set; } 
        }

        public class Link
        {
            public string href { get; set; }
        }


        public class CourseDetailResults
        {
            public List<Course> courses { get; set; }
        }
        public class Course
        {
            public string id { get; set; }
            public string displayCourseCode { get; set; }
            public string title { get; set; }
        }
    }
}
