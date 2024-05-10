using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StudentRepository
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        Task<List<StudentListDto>> GetListDto();

        Task<List<StudentListDto>> GetListByDepartmentId(int id);

        Task<List<CompanyListDto>> GetCompanyListByStudentId(int studentId);
    }
}