using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.DepartmentRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.DepartmentRepository
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, SimpleContextDb>, IDepartmentDal
    {
        public async Task<List<DepartmentListDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from department in context.Departments.Where(p => p.IsActive == true)
                             join faculty in context.Faculties
                             on department.FacultyId equals faculty.Id
                             select new DepartmentListDto
                             {
                                 Id = department.Id,
                                 Name = department.Name,
                                 FacultyId = department.FacultyId,
                                 FacultyName = faculty.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}