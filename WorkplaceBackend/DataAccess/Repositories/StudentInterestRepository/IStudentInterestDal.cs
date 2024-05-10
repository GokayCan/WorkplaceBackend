using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.StudentInterestRepository
{
    public interface IStudentInterestDal : IEntityRepository<StudentInterest>
    {
        Task<List<StudentInterestListDto>> GetListDtoByInterestId(int id);
        Task<List<StudentInterestListDto>> GetListDtoByStudentId(int id);
        Task<List<StudentInterestListDto>> GetListDto();
    }
}
