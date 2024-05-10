using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.LessonRepository
{
    public interface ILessonDal : IEntityRepository<Lesson>
    {
        Task<List<LessonListDto>> GetLessonListDto();
        Task<List<LessonListDto>> GetListByDepartmentId(int departmentId);

    }
}
