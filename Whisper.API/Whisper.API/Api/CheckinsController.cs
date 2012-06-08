using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using ScrappyDB.Linq;
using Whisper.API.Models;
using Whisper.API.Utilities;

namespace Whisper.API.Controllers
{
    public class CheckinsController : ApiController
    {
        public IEnumerable<StudentPoco> Course(string token, string id)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var decodedToken = PearsonApiUtilities.DecodeFrom64(token);

            Mapper.CreateMap<Student, StudentPoco>();

            var context = new StudentContext();

            var students = (from s in context.Students
                            where s.CourseIds.Every(id)
                            select s).ToList();

            foreach (var student in students)
            {
                try
                {
                    var userJson = PearsonApiUtilities.GetUserJson(decodedToken, student.StudentId);
                    var users = new JavaScriptSerializer().Deserialize<Users>(userJson);

                    student.FirstName = users.users[0].firstName;
                    student.LastName = users.users[0].lastName;
                }
                catch (Exception)
                {
                    //skip it... HACK
                }
            }

            var result = Mapper.Map<List<Student>, IEnumerable<StudentPoco>>(students);

            return result;
        }


    }

    public class Users
    {
        public List<User> users { get; set; }

        public class User
        {
            public string id { get; set; }
            public string userName { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string emailAddress { get; set; }
            public string clientString { get; set; }

        }
    }
}
