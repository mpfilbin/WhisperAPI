using System.Data.Entity;
using ScrappyDB.Linq;

namespace Whisper.API.Models
{
    public class StudentCheckinsContext : SdbContext
    {
        public SdbSet<Student> Students { get; set; }
    }
}
