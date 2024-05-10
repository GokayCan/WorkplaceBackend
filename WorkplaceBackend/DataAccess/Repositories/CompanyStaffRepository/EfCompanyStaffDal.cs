using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CompanyStaffRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CompanyStaffRepository
{
    public class EfCompanyStaffDal : EfEntityRepositoryBase<CompanyStaff, SimpleContextDb>, ICompanyStaffDal
    {
        public async Task<List<CompanyStaffListDto>> GetListDtoByCompanyId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from companyStaff in context.CompanyStaffs
                         join company in context.Companies on companyStaff.CompanyId equals company.Id
                         join staff in context.Staffs on companyStaff.StaffId equals staff.Id
                         join user in context.Users on staff.UserId equals user.Id
                         join department in context.Departments on staff.DepartmentId equals department.Id
                         where companyStaff.CompanyId == id && companyStaff.IsActive == true
                         select new CompanyStaffListDto
                         {
                             Id = companyStaff.Id,
                             CompanyId = companyStaff.CompanyId,
                             StaffId = companyStaff.StaffId,
                             DepartmentId = department.Id,
                             UserId = user.Id,
                             DepartmentName = department.Name,
                             UserName = user.FirstName + " " + user.LastName,
                             IsActive = companyStaff.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
