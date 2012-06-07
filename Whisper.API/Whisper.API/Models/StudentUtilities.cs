using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Whisper.API.Controllers;

namespace Whisper.API.Models
{
    public static class StudentUtilities
    {
        public static StudentPoco GetStudentPoco(string id)
        {
            Mapper.CreateMap<Student, StudentPoco>();

            var context = new StudentContext();

            var student = context.Students.Find(id);

            if (student == null)
                throw new Exception("Student not found...");

            var result = Mapper.Map<Student, StudentPoco>(student);

            return result;
        }
    }
}