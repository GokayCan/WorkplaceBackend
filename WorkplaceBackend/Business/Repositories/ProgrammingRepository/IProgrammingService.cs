using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.ProgrammingRepository
{
    public interface IProgrammingService
    {
        Task<IResult> Add(Programming programming);
        Task<IResult> Update(Programming programming);
        Task<IResult> Delete(Programming programming);
        Task<IDataResult<List<Programming>>> GetList();
        Task<IDataResult<Programming>> GetById(int id);
    }
}
