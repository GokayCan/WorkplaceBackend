using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.StudentRepository
{
    public interface IStudentService
    {
        Task<IResult> Add(Student student);

        Task<IResult> Update(Student student);

        Task<IResult> Delete(Student student);

        Task<IDataResult<List<StudentListDto>>> GetList();

        Task<IDataResult<List<CompanyListDto>>> GetCompanyListByStudentId(int studentId);

        Task<IDataResult<List<StudentListDto>>> GetListByDepartmentId(int id);

        Task<IDataResult<Student>> GetById(int id);
    }
}