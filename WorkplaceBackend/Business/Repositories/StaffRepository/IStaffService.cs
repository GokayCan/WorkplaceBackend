using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StaffRepository
{
    public interface IStaffService
    {
        Task<IResult> Add(StaffDto staffDto);

        Task<IResult> AddFromExcel(string filePath);

        Task<IResult> Update(StaffDto staffDto);

        Task<IResult> Delete(Staff staff);

        Task<IDataResult<List<StaffListDto>>> GetList();

        Task<IDataResult<StaffDto>> GetById(int id);

        Task<IDataResult<StaffDto>> GetByUserId(int UserId);
    }
}