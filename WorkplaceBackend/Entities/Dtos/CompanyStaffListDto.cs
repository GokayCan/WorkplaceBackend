using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CompanyStaffListDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
