using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.SectorRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.SectorRepository.Validation;
using Business.Repositories.SectorRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.SectorRepository;

namespace Business.Repositories.SectorRepository
{
    public class SectorManager : ISectorService
    {
        private readonly ISectorDal _sectorDal;

        public SectorManager(ISectorDal sectorDal)
        {
            _sectorDal = sectorDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(SectorValidator))]
        //[RemoveCacheAspect("ISectorService.Get")]

        public async Task<IResult> Add(Sector sector)
        {
            try
            {
                await _sectorDal.Add(sector);
                return new SuccessResult(SectorMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(SectorValidator))]
        //[RemoveCacheAspect("ISectorService.Get")]

        public async Task<IResult> Update(Sector sector)
        {
            try
            {
                await _sectorDal.Update(sector);
                return new SuccessResult(SectorMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ISectorService.Get")]

        public async Task<IResult> Delete(Sector sector)
        {
            try
            {
                await _sectorDal.Delete(sector);
                return new SuccessResult(SectorMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<Sector>>> GetList()
        {
            return new SuccessDataResult<List<Sector>>(await _sectorDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Sector>> GetById(int id)
        {
            return new SuccessDataResult<Sector>(await _sectorDal.Get(p => p.Id == id));
        }
    }
}