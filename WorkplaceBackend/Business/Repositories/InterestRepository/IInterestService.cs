using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.InterestRepository
{
    public interface IInterestService
    {
        Task<IResult> Add(Interest interest);
        Task<IResult> Update(Interest interest);
        Task<IResult> Delete(Interest interest);
        Task<IDataResult<List<Interest>>> GetList();
        Task<IDataResult<Interest>> GetById(int id);
    }
}
