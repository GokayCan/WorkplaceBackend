using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CompanyStudentRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CompanyStudentRepository
{
    public class EfCompanyStudentDal : EfEntityRepositoryBase<CompanyStudent, SimpleContextDb>, ICompanyStudentDal
    {
        public async Task<List<CompanyStudentListDto>> GetListDtoByCompanyId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from companyStudent in context.CompanyStudents
                         join company in context.Companies on companyStudent.CompanyId equals company.Id
                         join student in context.Students on companyStudent.StudentId equals student.Id
                         join department in context.Departments on student.DepartmentId equals department.Id
                         where companyStudent.CompanyId == id && companyStudent.IsActive == true
                         select new CompanyStudentListDto
                         {
                             Id = companyStudent.Id,
                             CompanyId = companyStudent.CompanyId,
                             StudentId = companyStudent.StudentId,
                             DepartmentId = department.Id,
                             DepartmentName = department.Name,
                             Email = student.Email,
                             Number = student.Number,
                             UserName = student.FirstName + " " + student.LastName,  
                             IsActive = companyStudent.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
