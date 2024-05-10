using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StudentLessonRepository
{
    public interface IStudentLessonService
    {
        Task<IResult> Add(StudentLesson studentLesson);
        Task<IResult> Update(StudentLesson studentLesson);
        Task<IResult> Delete(StudentLesson studentLesson);
        Task<IDataResult<List<StudentLesson>>> GetList();
        Task<IDataResult<List<StudentLessonListDto>>> GetListDto();
        Task<IDataResult<List<StudentLessonListDto>>> GetListByStudentId(int studentId);
        Task<IDataResult<StudentLesson>> GetById(int id);
    }
}
