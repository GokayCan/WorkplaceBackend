using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StudentInterestRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StudentInterestRepository
{
    public class EfStudentInterestDal : EfEntityRepositoryBase<StudentInterest, SimpleContextDb>, IStudentInterestDal
    {
        public async Task<List<StudentInterestListDto>> GetListDto()
        {
            using var context = new SimpleContextDb();
            var result = from studentInterest in context.StudentInterests.Where(x => x.IsActive == true)
                         join interest in context.Interests on studentInterest.InterestId equals interest.Id
                         join student in context.Students on studentInterest.StudentId equals student.Id
                         select new StudentInterestListDto
                         {
                             Id= studentInterest.Id,
                             StudentId= studentInterest.StudentId,
                             InterestId= studentInterest.InterestId,
                             InterestName = interest.Name,
                             StudentFirstName = student.FirstName, 
                             StudentLastName = student.LastName,
                             IsActive = studentInterest.IsActive,
                         };
            return await result.ToListAsync();
        }

        public async Task<List<StudentInterestListDto>> GetListDtoByInterestId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentInterest in context.StudentInterests.Where(x => x.IsActive == true)
                         join interest in context.Interests on studentInterest.InterestId equals interest.Id
                         join student in context.Students on studentInterest.StudentId equals student.Id
                         where studentInterest.InterestId == id
                         select new StudentInterestListDto
                         {
                             Id = studentInterest.Id,
                             StudentId = studentInterest.StudentId,
                             InterestId = studentInterest.InterestId,
                             InterestName = interest.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentInterest.IsActive,
                         };

            return await result.ToListAsync();
        }

        public async Task<List<StudentInterestListDto>> GetListDtoByStudentId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentInterest in context.StudentInterests.Where(x => x.IsActive == true)
                         join interest in context.Interests on studentInterest.InterestId equals interest.Id
                         join student in context.Students on studentInterest.StudentId equals student.Id
                         where studentInterest.StudentId == id
                         select new StudentInterestListDto
                         {
                             Id = studentInterest.Id,
                             StudentId = studentInterest.StudentId,
                             InterestId = studentInterest.InterestId,
                             InterestName = interest.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentInterest.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
