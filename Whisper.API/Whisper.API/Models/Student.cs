﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScrappyDB.Attributes;

namespace Whisper.API.Models
{
    [AutoCreateUpdateDates]
    public class Student : ScrappyDB.BaseClasses.SdbEntityWithLocation
    {
        public string StudentId { get; set; }

        public List<String> CourseIds { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }

    public class StudentPoco
    {
        public string StudentId { get; set; }

        public List<String> CourseIds { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}