using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.LessonRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.LessonRepository
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, SimpleContextDb>, ILessonDal
    {
        public async Task<List<LessonListDto>> GetLessonListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from lesson in context.Lessons.Where(p => p.IsActive)
                             join stuff in context.Staffs on lesson.StuffId equals stuff.Id
                             join user in context.Users on stuff.UserId equals user.Id
                             join department in context.Departments on lesson.DepartmentId equals department.Id
                             join semester in context.Semesters on lesson.SemesterId equals semester.Id
                             select new LessonListDto
                             {
                                 Id = lesson.Id,
                                 Name = lesson.Name,
                                 Code = lesson.Code,
                                 StuffName = user.FirstName +" " + user.LastName,
                                 DepartmentId = lesson.DepartmentId,
                                 DepartmentName = department.Name,
                                 Credit = lesson.Credit,
                                 Akts = lesson.Akts,
                                 SemesterId = lesson.SemesterId,
                                 SemesterName = semester.Name,
                                 IsSpring = lesson.IsSpring,
                                 CreatedBy = lesson.CreatedBy

                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<LessonListDto>> GetListByDepartmentId(int departmentId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from lesson in context.Lessons.Where(p => p.IsActive && p.DepartmentId== departmentId)
                             join stuff in context.Staffs on lesson.StuffId equals stuff.Id
                             join user in context.Users on stuff.UserId equals user.Id
                             join department in context.Departments on lesson.DepartmentId equals department.Id
                             join semester in context.Semesters on lesson.SemesterId equals semester.Id
                             select new LessonListDto
                             {
                                 Id = lesson.Id,
                                 Name = lesson.Name,
                                 Code = lesson.Code,
                                 StuffName = user.FirstName + " " + user.LastName,
                                 DepartmentId = lesson.DepartmentId,
                                 DepartmentName = department.Name,
                                 Credit = lesson.Credit,
                                 Akts = lesson.Akts,
                                 SemesterId = lesson.SemesterId,
                                 SemesterName = semester.Name,
                                 IsSpring = lesson.IsSpring,
                                 CreatedBy = lesson.CreatedBy

                             };
                return await result.ToListAsync();
            }
        }
    }
}
