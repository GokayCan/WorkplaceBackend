using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StudentProgrammingRepository
{
    public interface IStudentProgrammingService
    {
        Task<IResult> Add(StudentProgramming studentProgramming);
        Task<IResult> Update(StudentProgramming studentProgramming);
        Task<IResult> Delete(StudentProgramming studentProgramming);
        Task<IDataResult<List<StudentProgramming>>> GetList();
        Task<IDataResult<StudentProgramming>> GetById(int id);
        Task<IDataResult<List<StudentProgrammingListDto>>> GetListDtoByProgrammingId(int id);
        Task<IDataResult<List<StudentProgrammingListDto>>> GetListDtoByStudentId(int id);
        Task<IDataResult<List<StudentProgrammingListDto>>> GetListDto();
    }
}
