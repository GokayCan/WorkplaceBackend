using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.SemesterRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.SemesterRepository;

namespace Business.Repositories.SemesterRepository
{
    public class SemesterManager : ISemesterService
    {
        private readonly ISemesterDal _semesterDal;

        public SemesterManager(ISemesterDal semesterDal)
        {
            _semesterDal = semesterDal;
        }

        [SecuredAspect()]
       [RemoveCacheAspect("Business.Repositories.SemesterRepository.ISemesterService.GetList")]
        public async Task<IResult> Add(Semester semester)
        {
            await _semesterDal.Add(semester);
            return new SuccessResult("Kayıt Başarılı");
        }

        [SecuredAspect()]
       [RemoveCacheAspect("Business.Repositories.SemesterRepository.ISemesterService.GetList")]
        public async Task<IResult> Update(Semester semester)
        {
            await _semesterDal.Update(semester);
            return new SuccessResult("Kayıt Güncellendi.");
        }

        [SecuredAspect()]
       [RemoveCacheAspect("Business.Repositories.SemesterRepository.ISemesterService.GetList")]
        public async Task<IResult> Delete(Semester semester)
        {
            await _semesterDal.Delete(semester);
            return new SuccessResult("Kayıt Silindi");
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Semester>>> GetList()
        {
            return new SuccessDataResult<List<Semester>>(await _semesterDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Semester>> GetById(int id)
        {
            return new SuccessDataResult<Semester>(await _semesterDal.Get(p => p.Id == id));
        }

    }
}
