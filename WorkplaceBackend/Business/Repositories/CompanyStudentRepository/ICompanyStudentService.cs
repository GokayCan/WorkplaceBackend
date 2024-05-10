using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.CompanyStudentRepository
{
    public interface ICompanyStudentService
    {
        Task<IResult> Add(CompanyStudent companyStudent);

        Task<IResult> Update(CompanyStudent companyStudent);

        Task<IResult> Delete(CompanyStudent companyStudent);

        Task<IDataResult<List<CompanyStudent>>> GetList();

        Task<IDataResult<List<CompanyStudentListDto>>> GetListDtoByCompanyId(int id);

        Task<IDataResult<CompanyStudent>> GetById(int id);
    }
}