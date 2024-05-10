using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StaffRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StaffRepository
{
    public class EfStaffDal : EfEntityRepositoryBase<Staff, SimpleContextDb>, IStaffDal
    {
        public async Task<StaffDto> GetByUserId(int userId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from staff in context.Staffs.Where(x => x.UserId == userId)
                             join user in context.Users on staff.UserId equals user.Id
                             join department in context.Departments
                             on staff.DepartmentId equals department.Id
                             select new StaffDto
                             {
                                 Id = staff.Id,
                                 UserId = staff.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 DepartmentId = staff.DepartmentId,
                             };
                return await result.FirstAsync();
            }
        }

        public async Task<StaffDto> GetDto(int id)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from staff in context.Staffs.Where(x => x.Id == id)
                             join user in context.Users on staff.UserId equals user.Id
                             join department in context.Departments
                             on staff.DepartmentId equals department.Id
                             select new StaffDto
                             {
                                 Id = staff.Id,
                                 UserId = staff.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 DepartmentId = staff.DepartmentId,
                             };
                return await result.FirstAsync();
            }
        }

        public async Task<List<StaffListDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from staff in context.Staffs
                             join user in context.Users on staff.UserId equals user.Id
                             join department in context.Departments
                             on staff.DepartmentId equals department.Id
                             select new StaffListDto
                             {
                                 Id = staff.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 DepartmentId = staff.DepartmentId,
                                 DepartmentName = department.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}