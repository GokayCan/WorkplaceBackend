using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class LessonListDto:LessonDto
    {
        public string StuffName { get; set; }
        public string DepartmentName { get; set; }
        public string SemesterName { get; set; }
    }
}
