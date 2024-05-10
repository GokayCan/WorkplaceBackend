using Business.Repositories.CompanyStudentRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompanyStudentRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CompanyStudentRepository
{
    public class CompanyStudentManager : ICompanyStudentService
    {
        private readonly ICompanyStudentDal _companyStudentDal;

        public CompanyStudentManager(ICompanyStudentDal companyStudentDal)
        {
            _companyStudentDal = companyStudentDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyStudentValidator))]
        //[RemoveCacheAspect("ICompanyStudentService.Get")]

        public async Task<IResult> Add(CompanyStudent companyStudent)
        {
            try
            {
                var result = await _companyStudentDal.Get(p => p.StudentId == companyStudent.StudentId && p.IsActive == true);

                if (result != null)
                {
                    return new ErrorResult("Bu Öğrenci Bir Şirkete Zaten Kayıtlı");
                }

                companyStudent.CreatedBy = 1;
                companyStudent.CreatedDate = DateTime.Now;

                await _companyStudentDal.Add(companyStudent);
                return new SuccessResult(CompanyStudentMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyStudentValidator))]
        //[RemoveCacheAspect("ICompanyStudentService.Get")]

        public async Task<IResult> Update(CompanyStudent companyStudent)
        {
            try
            {
                var result = await _companyStudentDal.Get(p => p.StudentId == companyStudent.StudentId && p.Id != companyStudent.Id && p.IsActive == true);

                if (result != null)
                {
                    return new ErrorResult("Bu Öğrenci Bir Şirkete Zaten Kayıtlı");
                }

                await _companyStudentDal.Update(companyStudent);
                return new SuccessResult(CompanyStudentMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ICompanyStudentService.Get")]

        public async Task<IResult> Delete(CompanyStudent companyStudent)
        {
            try
            {
                var result = await _companyStudentDal.Get(p => p.Id == companyStudent.Id);
                result.IsActive = false;
                await _companyStudentDal.SoftDelete(result);
                return new SuccessResult(CompanyStudentMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<CompanyStudent>>> GetList()
        {
            return new SuccessDataResult<List<CompanyStudent>>(await _companyStudentDal.GetAll());
        }

        public async Task<IDataResult<List<CompanyStudentListDto>>> GetListDtoByCompanyId(int id)
        {
            return new SuccessDataResult<List<CompanyStudentListDto>>(await _companyStudentDal.GetListDtoByCompanyId(id));
        }

        //[SecuredAspect()]
        public async Task<IDataResult<CompanyStudent>> GetById(int id)
        {
            return new SuccessDataResult<CompanyStudent>(await _companyStudentDal.Get(p => p.Id == id));
        }
    }
}