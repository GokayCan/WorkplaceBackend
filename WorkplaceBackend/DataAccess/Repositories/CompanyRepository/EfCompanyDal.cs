using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CompanyRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CompanyRepository
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, SimpleContextDb>, ICompanyDal
    {
        public async Task<List<CompanyListDto>> GetCompaniesWithSectors()
        {
            using var context = new SimpleContextDb();

            var result = from company in context.Companies
                         join sector in context.Sectors on company.SectorId equals sector.Id
                         where company.IsActive == true
                         select new CompanyListDto
                         {
                             Id = company.Id,
                             Name = company.Name,
                             ResponsibleName = company.ResponsibleName,
                             PhoneNumber = company.PhoneNumber,
                             WebPage = company.WebPage,
                             SectorName = sector.Name,
                             SectorId = sector.Id,
                             Address = company.Address,
                             ProtocolDate = company.ProtocolDate,
                             ProtocolPersonel = company.ProtocolPersonel,
                             ResponsiblePhoneNumber = company.ResponsiblePhoneNumber,
                             IsActive = company.IsActive
                         };

            return await result.OrderBy(c=>c.Name).ToListAsync();
        }

        public async Task<List<CompanyListDto>> GetListBySectorId(int sectorId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from company in context.Companies
                                join sector in context.Sectors.Where(x=>x.Id==sectorId) on company.SectorId equals sector.Id
                                where company.IsActive == true
                                select new CompanyListDto
                                {
                                    Id = company.Id,
                                    Name = company.Name,
                                    ResponsibleName = company.ResponsibleName,
                                    PhoneNumber = company.PhoneNumber,
                                    WebPage = company.WebPage,
                                    SectorName = sector.Name,
                                    SectorId = sector.Id,
                                    Address = company.Address,
                                    ProtocolDate = company.ProtocolDate,
                                    ProtocolPersonel = company.ProtocolPersonel,
                                    ResponsiblePhoneNumber = company.ResponsiblePhoneNumber,
                                    IsActive = company.IsActive
                                };
                return await result.ToListAsync();
            }
        }
    }
}
