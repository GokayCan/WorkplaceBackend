using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.InterestRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.InterestRepository.Validation;
using Business.Repositories.InterestRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.InterestRepository;

namespace Business.Repositories.InterestRepository
{
    public class InterestManager : IInterestService
    {
        private readonly IInterestDal _interestDal;

        public InterestManager(IInterestDal interestDal)
        {
            _interestDal = interestDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(InterestValidator))]
        //[RemoveCacheAspect("IInterestService.Get")]

        public async Task<IResult> Add(Interest interest)
        {
            try
            {
                await _interestDal.Add(interest);
                return new SuccessResult(InterestMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(InterestValidator))]
        //[RemoveCacheAspect("IInterestService.Get")]

        public async Task<IResult> Update(Interest interest)
        {
            try
            {
                await _interestDal.Update(interest);
                return new SuccessResult(InterestMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IInterestService.Get")]

        public async Task<IResult> Delete(Interest interest)
        {
            try
            {
                await _interestDal.Delete(interest);
                return new SuccessResult(InterestMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<Interest>>> GetList()
        {
            return new SuccessDataResult<List<Interest>>(await _interestDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Interest>> GetById(int id)
        {
            return new SuccessDataResult<Interest>(await _interestDal.Get(p => p.Id == id));
        }
    }
}