using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StudentProgrammingRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StudentProgrammingRepository
{
    public class EfStudentProgrammingDal : EfEntityRepositoryBase<StudentProgramming, SimpleContextDb>, IStudentProgrammingDal
    {
        public async Task<List<StudentProgrammingListDto>> GetListDto()
        {
            using var context = new SimpleContextDb();
            var result = from studentProgramming in context.StudentProgrammings.Where(x => x.IsActive == true)
                         join programming in context.Programmings on studentProgramming.ProgrammingId equals programming.Id
                         join student in context.Students on studentProgramming.StudentId equals student.Id
                         select new StudentProgrammingListDto
                         {
                             Id = studentProgramming.Id,
                             StudentId = studentProgramming.StudentId,
                             ProgrammingId = studentProgramming.ProgrammingId,
                             ProgrammingName = programming.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentProgramming.IsActive,
                         };
            return await result.ToListAsync();
        }

        public async Task<List<StudentProgrammingListDto>> GetListDtoByProgrammingId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentProgramming in context.StudentProgrammings.Where(x => x.IsActive == true)
                         join programming in context.Programmings on studentProgramming.ProgrammingId equals programming.Id
                         join student in context.Students on studentProgramming.StudentId equals student.Id
                         where studentProgramming.ProgrammingId == id
                         select new StudentProgrammingListDto
                         {
                             Id = studentProgramming.Id,
                             StudentId = studentProgramming.StudentId,
                             ProgrammingId = studentProgramming.ProgrammingId,
                             ProgrammingName = programming.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentProgramming.IsActive,
                         };

            return await result.ToListAsync();
        }

        public async Task<List<StudentProgrammingListDto>> GetListDtoByStudentId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentProgramming in context.StudentProgrammings.Where(x => x.IsActive == true)
                         join programming in context.Programmings on studentProgramming.ProgrammingId equals programming.Id
                         join student in context.Students on studentProgramming.StudentId equals student.Id
                         where studentProgramming.StudentId == id
                         select new StudentProgrammingListDto
                         {
                             Id = studentProgramming.Id,
                             StudentId = studentProgramming.StudentId,
                             ProgrammingId = studentProgramming.ProgrammingId,
                             ProgrammingName = programming.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentProgramming.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
