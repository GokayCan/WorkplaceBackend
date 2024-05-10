using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StaffRepository
{
    public interface IStaffDal : IEntityRepository<Staff>
    {
        Task<StaffDto> GetDto(int id);

        Task<StaffDto> GetByUserId(int userId);

        Task<List<StaffListDto>> GetListDto();
    }
}