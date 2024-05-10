using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CompanyStudentListDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public string UserName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
