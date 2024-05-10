using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.CompanyResponsibleRepository
{
    public interface ICompanyResponsibleService
    {
        Task<IResult> Add(CompanyResponsible companyResponsible);
        Task<IResult> Update(CompanyResponsible companyResponsible);
        Task<IResult> Delete(CompanyResponsible companyResponsible);
        Task<IDataResult<List<CompanyResponsible>>> GetList();
        Task<IDataResult<List<CompanyResponsibleListDto>>> GetListDtoByCompanyId(int id);
        Task<IDataResult<CompanyResponsible>> GetById(int id);
    }
}
