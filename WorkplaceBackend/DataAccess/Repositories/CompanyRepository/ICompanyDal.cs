using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.CompanyRepository
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        Task<List<CompanyListDto>> GetCompaniesWithSectors();
        Task<List<CompanyListDto>> GetListBySectorId(int sectorId);

    }
}
