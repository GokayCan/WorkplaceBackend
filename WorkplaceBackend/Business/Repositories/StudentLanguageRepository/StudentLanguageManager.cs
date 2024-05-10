using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StudentLanguageRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StudentLanguageRepository.Validation;
using Business.Repositories.StudentLanguageRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentLanguageRepository;
using Entities.Dtos;

namespace Business.Repositories.StudentLanguageRepository
{
    public class StudentLanguageManager : IStudentLanguageService
    {
        private readonly IStudentLanguageDal _studentLanguageDal;

        public StudentLanguageManager(IStudentLanguageDal studentLanguageDal)
        {
            _studentLanguageDal = studentLanguageDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentLanguageValidator))]
        //[RemoveCacheAspect("IStudentLanguageService.Get")]

        public async Task<IResult> Add(StudentLanguage studentLanguage)
        {
            try
            {
                if (await _studentLanguageDal.Get(p => p.StudentId == studentLanguage.StudentId && p.LanguageId == studentLanguage.LanguageId) != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentLanguageDal.Add(studentLanguage);
                return new SuccessResult(StudentLanguageMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentLanguageValidator))]
        //[RemoveCacheAspect("IStudentLanguageService.Get")]

        public async Task<IResult> Update(StudentLanguage studentLanguage)
        {
            try
            {
                var result = await _studentLanguageDal.Get(p => p.StudentId == studentLanguage.StudentId && p.LanguageId == studentLanguage.LanguageId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentLanguageDal.Update(studentLanguage);
                return new SuccessResult(StudentLanguageMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IStudentLanguageService.Get")]

        public async Task<IResult> Delete(StudentLanguage studentLanguage)
        {
            try
            {
                var result = await _studentLanguageDal.Get(p => p.Id == studentLanguage.Id);
                result.IsActive = false;
                await _studentLanguageDal.SoftDelete(result);
                return new SuccessResult(StudentLanguageMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StudentLanguage>>> GetList()
        {
            return new SuccessDataResult<List<StudentLanguage>>(await _studentLanguageDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StudentLanguage>> GetById(int id)
        {
            return new SuccessDataResult<StudentLanguage>(await _studentLanguageDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<StudentLanguageListDto>>> GetListDto()
        {
            return new SuccessDataResult<List<StudentLanguageListDto>>(await _studentLanguageDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<List<StudentLanguageListDto>>> GetListDtoByLanguageId(int id)
        {
            return new SuccessDataResult<List<StudentLanguageListDto>>(await _studentLanguageDal.GetListDtoByLanguageId(id));
        }

        public async Task<IDataResult<List<StudentLanguageListDto>>> GetListDtoByStudentId(int id)
        {
            return new SuccessDataResult<List<StudentLanguageListDto>>(await _studentLanguageDal.GetListDtoByStudentId(id));
        }
    }
}