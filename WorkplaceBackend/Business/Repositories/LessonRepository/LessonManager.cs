using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.LessonRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.LessonRepository;
using Entities.Dtos;

namespace Business.Repositories.LessonRepository
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("Business.Repositories.LessonRepository.ILessonService.GetList")]
        public async Task<IResult> Add(Lesson lesson)
        {
            try
            {
                lesson.IsActive = true;
                lesson.CreatedDate = DateTime.Now;

                await _lessonDal.Add(lesson);
                return new SuccessResult("Kayıt Başarılı");
            }
            catch
            {
                return new ErrorResult("Kayıt Başarısız");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("Business.Repositories.LessonRepository.ILessonService.GetList")]
        public async Task<IResult> Update(Lesson lesson)
        {
            try
            {
                await _lessonDal.Update(lesson);
                return new SuccessResult("Kayıt Güncellendi.");
            }
            catch
            {
                return new ErrorResult("Güncelleme Başarısız");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("Business.Repositories.LessonRepository.ILessonService.GetList")]
        public async Task<IResult> Delete(Lesson lesson)
        {
            try
            {
                var result = await _lessonDal.Get(p => p.Id == lesson.Id);
                result.IsActive = false;

                await _lessonDal.SoftDelete(result);
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
        public async Task<IDataResult<List<Lesson>>> GetList()
        {
            return new SuccessDataResult<List<Lesson>>(await _lessonDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Lesson>> GetById(int id)
        {
            return new SuccessDataResult<Lesson>(await _lessonDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<LessonListDto>>> GetListDto()
        {
            return new SuccessDataResult<List<LessonListDto>>(await _lessonDal.GetLessonListDto());
        }

        public async Task<IDataResult<List<LessonListDto>>> GetListByDepartmentId(int departmentId)
        {
            return new SuccessDataResult<List<LessonListDto>>(await _lessonDal.GetListByDepartmentId(departmentId));
        }
    }
}
