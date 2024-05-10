using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StudentRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StudentRepository
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, SimpleContextDb>, IStudentDal
    {
        public async Task<List<CompanyListDto>> GetCompanyListByStudentId(int studentId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from companyStudent in context.CompanyStudents.Where(x => x.StudentId == studentId)
                             join company in context.Companies
                             on companyStudent.CompanyId equals company.Id
                             join sector in context.Sectors
                             on company.SectorId equals sector.Id
                             select new CompanyListDto
                             {
                                 Id = company.Id,
                                 Name = company.Name,
                                 Address = company.Address,
                                 PhoneNumber = company.PhoneNumber,
                                 SectorName = sector.Name,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<StudentListDto>> GetListByDepartmentId(int id)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from student in context.Students.Where(x => x.DepartmentId == id)
                             join department in context.Departments
                             on student.DepartmentId equals department.Id
                             select new StudentListDto
                             {
                                 Id = student.Id,
                                 FirstName = student.FirstName,
                                 LastName = student.LastName,
                                 Email = student.Email,
                                 Number = student.Number,
                                 DepartmentId = student.DepartmentId,
                                 DepartmentName = department.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<StudentListDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from student in context.Students
                             join department in context.Departments
                             on student.DepartmentId equals department.Id
                             select new StudentListDto
                             {
                                 Id = student.Id,
                                 FirstName = student.FirstName,
                                 LastName = student.LastName,
                                 Email = student.Email,
                                 Number = student.Number,
                                 DepartmentId = student.DepartmentId,
                                 DepartmentName = department.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}