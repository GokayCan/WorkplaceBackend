using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StudentProgrammingRepository
{
    public interface IStudentProgrammingDal : IEntityRepository<StudentProgramming>
    {
        Task<List<StudentProgrammingListDto>> GetListDtoByProgrammingId(int id);
        Task<List<StudentProgrammingListDto>> GetListDtoByStudentId(int id);
        Task<List<StudentProgrammingListDto>> GetListDto();
    }
}
