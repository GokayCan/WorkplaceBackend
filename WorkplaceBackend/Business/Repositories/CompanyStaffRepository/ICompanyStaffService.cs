using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.CompanyStaffRepository
{
    public interface ICompanyStaffService
    {
        Task<IResult> Add(CompanyStaff companyStaff);
        Task<IResult> Update(CompanyStaff companyStaff);
        Task<IResult> Delete(CompanyStaff companyStaff);
        Task<IDataResult<List<CompanyStaff>>> GetList();
        Task<IDataResult<List<CompanyStaffListDto>>> GetListDtoByCompanyId(int id);
        Task<IDataResult<CompanyStaff>> GetById(int id);
    }
}
