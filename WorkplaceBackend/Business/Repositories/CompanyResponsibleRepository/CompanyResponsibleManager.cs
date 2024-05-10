using Business.Repositories.CompanyResponsibleRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompanyResponsibleRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CompanyResponsibleRepository
{
    public class CompanyResponsibleManager : ICompanyResponsibleService
    {
        private readonly ICompanyResponsibleDal _companyResponsibleDal;

        public CompanyResponsibleManager(ICompanyResponsibleDal companyResponsibleDal)
        {
            _companyResponsibleDal = companyResponsibleDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyResponsibleValidator))]
        //[RemoveCacheAspect("ICompanyResponsibleService.Get")]

        public async Task<IResult> Add(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleDal.Get(p => p.Id != companyResponsible.Id && p.CompanyId == companyResponsible.CompanyId && p.ResponsibleId == companyResponsible.ResponsibleId && p.IsActive == true);

            if (result != null)
            {
                return new ErrorResult("İlgili Kişi Zaten Kayıt Edilmiş");
            }

            companyResponsible.CreatedBy = 1;
            companyResponsible.CreatedDate = DateTime.Now;

            await _companyResponsibleDal.Add(companyResponsible);
            return new SuccessResult(CompanyResponsibleMessages.Added);
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyResponsibleValidator))]
        //[RemoveCacheAspect("ICompanyResponsibleService.Get")]

        public async Task<IResult> Update(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleDal.Get(p => p.Id != companyResponsible.Id && p.Id != companyResponsible.Id && p.CompanyId == companyResponsible.CompanyId && p.ResponsibleId == companyResponsible.ResponsibleId && p.IsActive == true);

            if (result != null)
            {
                return new ErrorResult("İlgili Kişi Zaten Kayıt Edilmiş");
            }

            await _companyResponsibleDal.Update(companyResponsible);
            return new SuccessResult(CompanyResponsibleMessages.Updated);
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ICompanyResponsibleService.Get")]

        public async Task<IResult> Delete(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleDal.Get(p => p.Id == companyResponsible.Id);
            result.IsActive = false;
            await _companyResponsibleDal.SoftDelete(result);
            return new SuccessResult(CompanyResponsibleMessages.Deleted);
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<CompanyResponsible>>> GetList()
        {
            return new SuccessDataResult<List<CompanyResponsible>>(await _companyResponsibleDal.GetAll());
        }

        public async Task<IDataResult<List<CompanyResponsibleListDto>>> GetListDtoByCompanyId(int id)
        {
            return new SuccessDataResult<List<CompanyResponsibleListDto>>(await _companyResponsibleDal.GetListDtoByCompanyId(id));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CompanyResponsible>> GetById(int id)
        {
            return new SuccessDataResult<CompanyResponsible>(await _companyResponsibleDal.Get(p => p.Id == id));
        }
    }
}