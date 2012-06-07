using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Whisper.API.Controllers
{
    public class CoursesController : ApiController
    {
        // GET /api/courses
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /api/courses/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/courses
        public void Post(string value)
        {
        }

        // PUT /api/courses/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/courses/5
        public void Delete(int id)
        {
        }
    }
}
