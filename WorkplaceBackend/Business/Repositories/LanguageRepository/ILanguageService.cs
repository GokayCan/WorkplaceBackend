using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.LanguageRepository
{
    public interface ILanguageService
    {
        Task<IResult> Add(Language language);
        Task<IResult> Update(Language language);
        Task<IResult> Delete(Language language);
        Task<IDataResult<List<Language>>> GetList();
        Task<IDataResult<Language>> GetById(int id);
    }
}
