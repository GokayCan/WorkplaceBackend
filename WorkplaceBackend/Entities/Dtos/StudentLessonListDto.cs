using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentLessonListDto:StudentLessonDto
    {
        public string StudentName { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public int StuffId { get; set; }
        public int DepartmentId { get; set; }
        public int Credit { get; set; }
        public int Akts { get; set; }
        public int SemesterId { get; set; }
        public bool IsSpring { get; set; }


        public string StuffName { get; set; }
        public string DepartmentName { get; set; }
        public string SemesterName { get; set; }



    }
}
