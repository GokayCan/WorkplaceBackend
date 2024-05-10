using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CompanyResponsibleRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CompanyResponsibleRepository
{
    public class EfCompanyResponsibleDal : EfEntityRepositoryBase<CompanyResponsible, SimpleContextDb>, ICompanyResponsibleDal
    {
        public async Task<List<CompanyResponsibleListDto>> GetListDtoByCompanyId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from companyResponsible in context.CompanyResponsibles
                         join company in context.Companies on companyResponsible.CompanyId equals company.Id
                         join staff in context.Staffs on companyResponsible.ResponsibleId equals staff.Id
                         join user in context.Users on staff.UserId equals user.Id
                         join department in context.Departments on staff.DepartmentId equals department.Id
                         where companyResponsible.CompanyId == id && companyResponsible.IsActive == true
                         select new CompanyResponsibleListDto
                         {
                             Id = companyResponsible.Id,
                             CompanyId = companyResponsible.CompanyId,
                             DepartmentId = department.Id,
                             ResponsibleId = companyResponsible.ResponsibleId,
                             UserId = user.Id,
                             DepartmentName = department.Name,
                             UserName = user.FirstName + " " + user.LastName,
                             IsActive = companyResponsible.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
