using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.SemesterRepository
{
    public interface ISemesterService
    {
        Task<IResult> Add(Semester semester);
        Task<IResult> Update(Semester semester);
        Task<IResult> Delete(Semester semester);
        Task<IDataResult<List<Semester>>> GetList();
        Task<IDataResult<Semester>> GetById(int id);
    }
}
