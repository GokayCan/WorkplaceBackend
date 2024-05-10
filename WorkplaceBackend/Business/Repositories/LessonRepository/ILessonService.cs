using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.LessonRepository
{
    public interface ILessonService
    {
        Task<IResult> Add(Lesson lesson);
        Task<IResult> Update(Lesson lesson);
        Task<IResult> Delete(Lesson lesson);
        Task<IDataResult<List<Lesson>>> GetList();
        Task<IDataResult<List<LessonListDto>>> GetListDto();
        Task<IDataResult<List<LessonListDto>>> GetListByDepartmentId(int departmentId);
        Task<IDataResult<Lesson>> GetById(int id);
    }
}
