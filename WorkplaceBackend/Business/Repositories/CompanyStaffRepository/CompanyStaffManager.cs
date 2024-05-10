using Business.Repositories.CompanyStaffRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompanyStaffRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CompanyStaffRepository
{
    public class CompanyStaffManager : ICompanyStaffService
    {
        private readonly ICompanyStaffDal _companyStaffDal;

        public CompanyStaffManager(ICompanyStaffDal companyStaffDal)
        {
            _companyStaffDal = companyStaffDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyStaffValidator))]
        //[RemoveCacheAspect("ICompanyStaffService.Get")]

        public async Task<IResult> Add(CompanyStaff companyStaff)
        {
            try
            {
                var result = await _companyStaffDal.Get(p => p.CompanyId == companyStaff.CompanyId && p.StaffId == companyStaff.StaffId && p.IsActive == true);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayıt Zaten Mevcut");
                }

                companyStaff.CreatedBy = 1;
                companyStaff.CreatedDate = DateTime.Now;

                await _companyStaffDal.Add(companyStaff);
                return new SuccessResult(CompanyStaffMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme İşlemi Başrısız");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyStaffValidator))]
        //[RemoveCacheAspect("ICompanyStaffService.Get")]

        public async Task<IResult> Update(CompanyStaff companyStaff)
        {
            try
            {
                var result = await _companyStaffDal.Get(p => p.CompanyId == companyStaff.CompanyId && p.StaffId == companyStaff.StaffId && p.IsActive == true);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayıt Zaten Mevcut");
                }

                await _companyStaffDal.Update(companyStaff);
                return new SuccessResult(CompanyStaffMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme İşlemi Başrısız");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ICompanyStaffService.Get")]

        public async Task<IResult> Delete(CompanyStaff companyStaff)
        {
            try
            {
                var result = await _companyStaffDal.Get(p => p.Id == companyStaff.Id);
                result.IsActive = false;
                await _companyStaffDal.SoftDelete(result);
                return new SuccessResult(CompanyStaffMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme İşlemi Başrısız");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<CompanyStaff>>> GetList()
        {
            return new SuccessDataResult<List<CompanyStaff>>(await _companyStaffDal.GetAll());
        }

        public async Task<IDataResult<List<CompanyStaffListDto>>> GetListDtoByCompanyId(int id)
        {
            return new SuccessDataResult<List<CompanyStaffListDto>>(await _companyStaffDal.GetListDtoByCompanyId(id));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CompanyStaff>> GetById(int id)
        {
            return new SuccessDataResult<CompanyStaff>(await _companyStaffDal.Get(p => p.Id == id));
        }
    }
}