using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.LanguageRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.LanguageRepository.Validation;
using Business.Repositories.LanguageRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.LanguageRepository;

namespace Business.Repositories.LanguageRepository
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(LanguageValidator))]
        //[RemoveCacheAspect("ILanguageService.Get")]

        public async Task<IResult> Add(Language language)
        {
            try
            {
                await _languageDal.Add(language);
                return new SuccessResult(LanguageMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(LanguageValidator))]
        //[RemoveCacheAspect("ILanguageService.Get")]

        public async Task<IResult> Update(Language language)
        {
            try
            {
                await _languageDal.Update(language);
                return new SuccessResult(LanguageMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ILanguageService.Get")]

        public async Task<IResult> Delete(Language language)
        {
            try
            {
                await _languageDal.Delete(language);
                return new SuccessResult(LanguageMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<Language>>> GetList()
        {
            return new SuccessDataResult<List<Language>>(await _languageDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Language>> GetById(int id)
        {
            return new SuccessDataResult<Language>(await _languageDal.Get(p => p.Id == id));
        }
    }
}