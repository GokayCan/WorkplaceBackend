using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.CompanyRepository
{
    public interface ICompanyService
    {
        Task<IResult> Add(Company company);
        Task<IResult> Update(Company company);
        Task<IResult> Delete(Company company);
        Task<IDataResult<List<CompanyListDto>>> GetList();
        Task<IDataResult<List<CompanyListDto>>> GetListBySectorId(int sectorId);
        Task<IDataResult<Company>> GetById(int id);
        Task<IResult> ExcelToDB();
        Task<IResult> ChangeData();
    }
}
