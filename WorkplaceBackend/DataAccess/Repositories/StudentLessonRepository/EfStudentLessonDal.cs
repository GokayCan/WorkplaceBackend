using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StudentLessonRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StudentLessonRepository
{
    public class EfStudentLessonDal : EfEntityRepositoryBase<StudentLesson, SimpleContextDb>, IStudentLessonDal
    {
        public async Task<List<StudentLessonListDto>> GetStudentLessonListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from studentLesson in context.StudentLessons.Where(p => p.IsActive)
                             join student in context.Students on studentLesson.StudentId equals student.Id
                             join lesson in context.Lessons on studentLesson.LessonId equals lesson.Id
                             join stuff in context.Staffs on lesson.StuffId equals stuff.Id
                             join user in context.Users on stuff.UserId equals user.Id
                             join department in context.Departments on lesson.DepartmentId equals department.Id
                             join semester in context.Semesters on lesson.SemesterId equals semester.Id
                             select new StudentLessonListDto
                             {
                                 Id = studentLesson.Id,
                                 StudentId = student.Id,
                                 StudentName = student.FirstName + " " + student.LastName,
                                 Midtern = studentLesson.Midtern !=null ? studentLesson.Midtern : null,
                                 Project = studentLesson.Project != null ? studentLesson.Project : null,
                                 Quiz = studentLesson.Quiz != null ? studentLesson.Quiz : null,
                                 Final = studentLesson.Final != null ? studentLesson.Final : null,
                                 Average = studentLesson.Average != null ? studentLesson.Average : null,
                                 
                                 LessonId = lesson.Id,
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
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<StudentLessonListDto>> GetStudentLessonsByStudentId(int studentId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from studentLesson in context.StudentLessons.Where(p => p.IsActive && p.StudentId ==studentId)
                             join student in context.Students on studentLesson.StudentId equals student.Id
                             join lesson in context.Lessons on studentLesson.LessonId equals lesson.Id
                             join stuff in context.Staffs on lesson.StuffId equals stuff.Id
                             join user in context.Users on stuff.UserId equals user.Id
                             join department in context.Departments on lesson.DepartmentId equals department.Id
                             join semester in context.Semesters on lesson.SemesterId equals semester.Id
                             select new StudentLessonListDto
                             {
                                 Id = studentLesson.Id,
                                 StudentId = student.Id,
                                 StudentName = student.FirstName + " " + student.LastName,
                                 Midtern = studentLesson.Midtern != null ? studentLesson.Midtern : null,
                                 Project = studentLesson.Project != null ? studentLesson.Project : null,
                                 Quiz = studentLesson.Quiz != null ? studentLesson.Quiz : null,
                                 Final = studentLesson.Final != null ? studentLesson.Final : null,
                                 Average = studentLesson.Average != null ? studentLesson.Average : null,

                                 LessonId = lesson.Id,
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
                             };
                return await result.ToListAsync();
            }
        }
    }
}
