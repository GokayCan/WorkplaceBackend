using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StudentLessonRepository
{
    public interface IStudentLessonDal : IEntityRepository<StudentLesson>
    {
        Task<List<StudentLessonListDto>> GetStudentLessonListDto();

        Task<List<StudentLessonListDto>> GetStudentLessonsByStudentId(int studentId);

    }
}
