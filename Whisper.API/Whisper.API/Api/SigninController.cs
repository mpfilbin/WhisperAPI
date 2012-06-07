using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Whisper.API.Controllers
{
    public class SigninController : ApiController
    {
        // GET /api/signin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /api/signin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/signin
        public string Post(string username, string password)
        {
            return "123";
        }

        // PUT /api/signin/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/signin/5
        public void Delete(int id)
        {
        }
    }
}
