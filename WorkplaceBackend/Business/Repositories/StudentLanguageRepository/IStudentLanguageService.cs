using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StudentLanguageRepository
{
    public interface IStudentLanguageService
    {
        Task<IResult> Add(StudentLanguage studentLanguage);
        Task<IResult> Update(StudentLanguage studentLanguage);
        Task<IResult> Delete(StudentLanguage studentLanguage);
        Task<IDataResult<List<StudentLanguage>>> GetList();
        Task<IDataResult<StudentLanguage>> GetById(int id);
        Task<IDataResult<List<StudentLanguageListDto>>> GetListDtoByLanguageId(int id);
        Task<IDataResult<List<StudentLanguageListDto>>> GetListDtoByStudentId(int id);
        Task<IDataResult<List<StudentLanguageListDto>>> GetListDto();
    }
}
