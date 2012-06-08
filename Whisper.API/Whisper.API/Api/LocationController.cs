using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using ScrappyDB;
using ScrappyDB.Linq;
using Whisper.API.Models;

namespace Whisper.API.Controllers
{
    public class StudentContext : SdbContext
    {
        public SdbSet<Student> Students { get; set; }
    }
    public class LocationController : ApiController
    {

        [AcceptVerbs("GET", "POST")]
        public IEnumerable<StudentPoco> Checkin( string studentId, string courseId, double lat, double lon)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            return UpdateStudent(studentId, courseId, lat, lon);
        }



        private static IEnumerable<StudentPoco> UpdateStudent( string studentId, string courseId, double lat, double lon)
        {
            Mapper.CreateMap<Student, StudentPoco>();

            var context = new StudentContext();

            var student = context.Students.Find(studentId);

            if (student == null)
            {
                //throw new Exception("Student not found...");

                //for demo purposes create a student
                student = new Student
                              {
                                  StudentId = studentId,
                                  CourseIds = new List<string>() { courseId }
                              };
            }

            if (!student.CourseIds.Contains(courseId))
                student.CourseIds.Add(courseId);

            student.LastUpdated = DateTime.Now;
            student.Latitude = lat;
            student.Longitude = lon;

            student.Save();


            var students = (from s in context.Students
                            where s.CourseIds.Every(courseId)
                            select s).ToList();

            var result = Mapper.Map<List<Student>, IEnumerable<StudentPoco>>(students);

            return result;
        }
    }
}
