using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StudentLanguageRepository
{
    public interface IStudentLanguageDal : IEntityRepository<StudentLanguage>
    {
        Task<List<StudentLanguageListDto>> GetListDtoByLanguageId(int id);
        Task<List<StudentLanguageListDto>> GetListDtoByStudentId(int id);
        Task<List<StudentLanguageListDto>> GetListDto();
    }
}
