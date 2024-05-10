using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StudentLesson
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public decimal? Midtern { get; set; }
        public decimal? Project { get; set; }
        public decimal? Quiz { get; set; }
        public decimal? Final { get; set; }
        public decimal? Average { get; set; }
        public bool IsActive { get; set; }
    }
}
