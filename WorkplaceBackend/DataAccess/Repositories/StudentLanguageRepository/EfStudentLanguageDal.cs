using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StudentLanguageRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StudentLanguageRepository
{
    public class EfStudentLanguageDal : EfEntityRepositoryBase<StudentLanguage, SimpleContextDb>, IStudentLanguageDal
    {
        public async Task<List<StudentLanguageListDto>> GetListDto()
        {
            using var context = new SimpleContextDb();
            var result = from studentLanguage in context.StudentLanguages.Where(x => x.IsActive == true)
                         join language in context.Languages on studentLanguage.LanguageId equals language.Id
                         join student in context.Students on studentLanguage.StudentId equals student.Id
                         select new StudentLanguageListDto
                         {
                             Id = studentLanguage.Id,
                             StudentId = studentLanguage.StudentId,
                             LanguageId = studentLanguage.LanguageId,
                             LanguageName = language.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentLanguage.IsActive,
                         };
            return await result.ToListAsync();
        }

        public async Task<List<StudentLanguageListDto>> GetListDtoByLanguageId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentLanguage in context.StudentLanguages.Where(x => x.IsActive == true)
                         join language in context.Languages on studentLanguage.LanguageId equals language.Id
                         join student in context.Students on studentLanguage.StudentId equals student.Id
                         where studentLanguage.LanguageId == id
                         select new StudentLanguageListDto
                         {
                             Id = studentLanguage.Id,
                             StudentId = studentLanguage.StudentId,
                             LanguageId = studentLanguage.LanguageId,
                             LanguageName = language.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentLanguage.IsActive,
                         };

            return await result.ToListAsync();
        }

        public async Task<List<StudentLanguageListDto>> GetListDtoByStudentId(int id)
        {
            using var context = new SimpleContextDb();

            var result = from studentLanguage in context.StudentLanguages.Where(x => x.IsActive == true)
                         join language in context.Languages on studentLanguage.LanguageId equals language.Id
                         join student in context.Students on studentLanguage.StudentId equals student.Id
                         where studentLanguage.StudentId == id
                         select new StudentLanguageListDto
                         {
                             Id = studentLanguage.Id,
                             StudentId = studentLanguage.StudentId,
                             LanguageId = studentLanguage.LanguageId,
                             LanguageName = language.Name,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                             IsActive = studentLanguage.IsActive,
                         };

            return await result.ToListAsync();
        }
    }
}
