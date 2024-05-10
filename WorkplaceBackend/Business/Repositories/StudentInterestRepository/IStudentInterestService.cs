using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StudentInterestRepository
{
    public interface IStudentInterestService
    {
        Task<IResult> Add(StudentInterest studentInterest);
        Task<IResult> Update(StudentInterest studentInterest);
        Task<IResult> Delete(StudentInterest studentInterest);
        Task<IDataResult<List<StudentInterest>>> GetList();
        Task<IDataResult<StudentInterest>> GetById(int id);
        Task<IDataResult<List<StudentInterestListDto>>> GetListDtoByInterestId(int id);
        Task<IDataResult<List<StudentInterestListDto>>> GetListDtoByStudentId(int id);
        Task<IDataResult<List<StudentInterestListDto>>> GetListDto();
    }
}
