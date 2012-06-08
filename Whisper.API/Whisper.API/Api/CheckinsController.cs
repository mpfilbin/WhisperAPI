using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ScrappyDB.Linq;
using Whisper.API.Models;

namespace Whisper.API.Controllers
{
    public class CheckinsController : ApiController
    {
        public IEnumerable<StudentPoco> Course(string id)
        {
            Mapper.CreateMap<Student, StudentPoco>();

            var context = new StudentContext();

            var students = (from s in context.Students
                            where s.CourseIds.Every(id)
                            select s).ToList();

            var result = Mapper.Map<List<Student>, IEnumerable<StudentPoco>>(students);

            return result;
        }


    }
}
