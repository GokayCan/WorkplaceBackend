using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code{ get; set; }
        public int StuffId{ get; set; }
        public int DepartmentId{ get; set; }
        public int Credit{ get; set; }
        public int Akts{ get; set; }
        public int SemesterId{ get; set; }
        public bool IsSpring{ get; set; }

        public int CreatedBy{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public bool IsActive{ get; set; }

    }
}
