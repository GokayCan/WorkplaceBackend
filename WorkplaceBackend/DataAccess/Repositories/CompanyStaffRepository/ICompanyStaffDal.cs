using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.CompanyStaffRepository
{
    public interface ICompanyStaffDal : IEntityRepository<CompanyStaff>
    {
        Task<List<CompanyStaffListDto>> GetListDtoByCompanyId(int id);
    }
}
