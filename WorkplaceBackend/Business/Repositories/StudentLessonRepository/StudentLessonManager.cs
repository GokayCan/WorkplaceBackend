using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StudentLessonRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentLessonRepository;
using Entities.Dtos;

namespace Business.Repositories.StudentLessonRepository
{
    public class StudentLessonManager : IStudentLessonService
    {
        private readonly IStudentLessonDal _studentLessonDal;

        public StudentLessonManager(IStudentLessonDal studentLessonDal)
        {
            _studentLessonDal = studentLessonDal;
        }

       // [SecuredAspect()]
       //[RemoveCacheAspect("Business.Repositories.StudentLessonRepository.IStudentLessonService.GetList")]
        public async Task<IResult> Add(StudentLesson studentLesson)
        {
            try
            {
                var result = await _studentLessonDal.Get(p => p.StudentId == studentLesson.StudentId && p.LessonId == studentLesson.LessonId);
                if (result != null)
                {
                    return new ErrorResult("Bu Kayıt Zaten Mevcut");
                }
                await _studentLessonDal.Add(studentLesson);
                return new SuccessResult("Kayıt Başarılı");
            }
            catch
            {
                return new ErrorResult("Ekleme İşlemi Başarısız");
            }
        }

       // [SecuredAspect()]
       //[RemoveCacheAspect("Business.Repositories.StudentLessonRepository.IStudentLessonService.GetList")]
        public async Task<IResult> Update(StudentLesson studentLesson)
        {
            try
            {
                var result = await _studentLessonDal.Get(p => p.Id == studentLesson.Id);
                if (result == null)
                {
                    return new ErrorResult("Kayıt Bulunamadı");
                }
                await _studentLessonDal.Update(studentLesson);
                return new SuccessResult("Kayıt Güncellendi.");
            }
            catch
            {
                return new ErrorResult("Güncelleme Başarısız");
            }
        }

       // [SecuredAspect()]
       //[RemoveCacheAspect("Business.Repositories.StudentLessonRepository.IStudentLessonService.GetList")]
        public async Task<IResult> Delete(StudentLesson studentLesson)
        {
            try
            {
                var result = await _studentLessonDal.Get(p => p.Id == studentLesson.Id);
                result.IsActive = false;
                await _studentLessonDal.SoftDelete(result);
                return new SuccessResult("Kayıt Silindi");
            }
            catch
            {
                return new ErrorResult("Silme Başarısız");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StudentLesson>>> GetList()
        {
            return new SuccessDataResult<List<StudentLesson>>(await _studentLessonDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StudentLesson>> GetById(int id)
        {
            return new SuccessDataResult<StudentLesson>(await _studentLessonDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<StudentLessonListDto>>> GetListDto()
        {
            return new SuccessDataResult<List<StudentLessonListDto>>(await _studentLessonDal.GetStudentLessonListDto());
        }

        public async Task<IDataResult<List<StudentLessonListDto>>> GetListByStudentId(int studentId)
        {
            return new SuccessDataResult<List<StudentLessonListDto>>(await _studentLessonDal.GetStudentLessonsByStudentId(studentId));
        }
    }
}
