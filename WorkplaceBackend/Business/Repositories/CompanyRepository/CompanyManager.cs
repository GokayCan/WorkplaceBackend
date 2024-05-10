using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CompanyRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CompanyRepository.Validation;
using Business.Repositories.CompanyRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompanyRepository;
using System.Reflection.Metadata;
using Business.Utilities.ExcelReader;
using DataAccess.Repositories.SectorRepository;
using Entities.Dtos;

namespace Business.Repositories.CompanyRepository
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        private readonly ISectorDal _sectorDal;
        private readonly IExcelService _excelService;

        public CompanyManager(ICompanyDal companyDal, IExcelService excelService, ISectorDal sectorDal)
        {
            _companyDal = companyDal;
            _excelService = excelService;
            _sectorDal = sectorDal;
        }

        public async Task<IResult> ExcelToDB()
        {
            var comps = await _excelService.WorkPlaceAddWithExcelFile("C:\\Users\\Alperen\\Desktop\\Worklplace\\FINALIZED.xlsx");
            List<Company> compList = comps.Data;
            foreach (var item in compList)
            {
                await _companyDal.Add(item);
            }

            return new SuccessResult();
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyValidator))]
        //[RemoveCacheAspect("ICompanyService.Get")]

        public async Task<IResult> Add(Company company)
        {
            try
            {
                var list = await _companyDal.GetAll();

                var result = list.Any(x => x.Name == company.Name || x.ResponsibleName == company.ResponsibleName || x.PhoneNumber == company.PhoneNumber || x.WebPage == company.WebPage);

                if (result)
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                company.CreatedBy = 1;
                company.CreatedDate = DateTime.Now;

                await _companyDal.Add(company);
                return new SuccessResult(CompanyMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(CompanyValidator))]
        //[RemoveCacheAspect("ICompanyService.Get")]

        public async Task<IResult> Update(Company company)
        {
            try
            {
                var list = await _companyDal.GetAll();

                var exist = await _companyDal.Get(x => x.Id == company.Id);

                company.Name = company.Name.Trim();
                company.ResponsibleName = company.ResponsibleName.Trim();
                company.PhoneNumber = company.PhoneNumber.Trim();
                company.WebPage = company.WebPage.Trim();
                company.ResponsiblePhoneNumber = company.ResponsiblePhoneNumber.Trim();
                company.ProtocolPersonel = company.ProtocolPersonel.Trim();
                company.Address = company.Address.Trim();

                list.RemoveAll(x => x.Id == company.Id);
                if (list.Any(x => x.Name == company.Name))
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                if (list.Any(x => x.ResponsibleName == company.ResponsibleName))
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                if (list.Any(x => x.PhoneNumber == company.PhoneNumber))
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                if (list.Any(x => x.WebPage == company.WebPage))
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                if ((exist.Name == company.Name) && (exist.ResponsibleName == company.ResponsibleName) && (exist.PhoneNumber == company.PhoneNumber)
                    && (exist.WebPage == company.WebPage) && (exist.ResponsiblePhoneNumber == company.ResponsiblePhoneNumber) && (exist.ProtocolPersonel == company.ProtocolPersonel) && (exist.Address == company.Address))
                {
                    return new ErrorResult(CompanyMessages.AlreadyExists);
                }

                //hatýraaaaa

                //if (!exist.Equals(company))
                //{
                //    list.RemoveAll(x => x.Id == company.Id);
                //    var result = list.Any(x => x.Name == company.Name || x.ResponsibleName == company.ResponsibleName || x.PhoneNumber == company.PhoneNumber || x.WebPage == company.WebPage);

                //    if (result)
                //    {
                //        return new ErrorResult(CompanyMessages.AlreadyExists);
                //    }
                //}
                //if (exist == company)
                //{
                //    return new ErrorResult(CompanyMessages.AlreadyExists);
                //}

                await _companyDal.Update(company);
                return new SuccessResult(CompanyMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("ICompanyService.Get")]

        public async Task<IResult> Delete(Company company)
        {
            try
            {
                var result = await _companyDal.Get(p => p.Id == company.Id);
                result.IsActive = false;
                await _companyDal.SoftDelete(result);
                return new SuccessResult(CompanyMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme İşlemi Başarısız");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<CompanyListDto>>> GetList()
        {
            return new SuccessDataResult<List<CompanyListDto>>(await _companyDal.GetCompaniesWithSectors());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Company>> GetById(int id)
        {
            return new SuccessDataResult<Company>(await _companyDal.Get(p => p.Id == id));
        }

        public async Task<IResult> ChangeData()
        {
            var companyList = await _companyDal.GetAll();
            var sectorList = await _sectorDal.GetAll();

            foreach (var company in companyList)
            {
                foreach (var sector in sectorList)
                {
                    //if (company.Sector.ToLower() == sector.Name.ToLower())
                    //{
                    //    company.SectorId = sector.Id;
                    //    _ = _companyDal.Update(company);
                    //}
                }
            }
            return new SuccessResult("İşlem Tamam");
        }

        public async Task<IDataResult<List<CompanyListDto>>> GetListBySectorId(int sectorId)
        {
            return new SuccessDataResult<List<CompanyListDto>>(await _companyDal.GetListBySectorId(sectorId));
        }
    }
}