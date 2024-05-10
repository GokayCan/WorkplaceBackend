using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.ProgrammingRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.ProgrammingRepository.Validation;
using Business.Repositories.ProgrammingRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ProgrammingRepository;

namespace Business.Repositories.ProgrammingRepository
{
    public class ProgrammingManager : IProgrammingService
    {
        private readonly IProgrammingDal _programmingDal;

        public ProgrammingManager(IProgrammingDal programmingDal)
        {
            _programmingDal = programmingDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(ProgrammingValidator))]
        //[RemoveCacheAspect("IProgrammingService.Get")]

        public async Task<IResult> Add(Programming programming)
        {
            try
            {
                await _programmingDal.Add(programming);
                return new SuccessResult(ProgrammingMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(ProgrammingValidator))]
        //[RemoveCacheAspect("IProgrammingService.Get")]

        public async Task<IResult> Update(Programming programming)
        {
            try
            {
                await _programmingDal.Update(programming);
                return new SuccessResult(ProgrammingMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IProgrammingService.Get")]

        public async Task<IResult> Delete(Programming programming)
        {
            try
            {
                var result = await _programmingDal.Get(p => p.Id == programming.Id);
                result.IsActive = false;
                await _programmingDal.SoftDelete(result);
                return new SuccessResult(ProgrammingMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<Programming>>> GetList()
        {
            return new SuccessDataResult<List<Programming>>(await _programmingDal.GetAll(p => p.IsActive == true));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Programming>> GetById(int id)
        {
            return new SuccessDataResult<Programming>(await _programmingDal.Get(p => p.Id == id));
        }
    }
}