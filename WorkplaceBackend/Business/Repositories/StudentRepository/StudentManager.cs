using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StudentRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StudentRepository.Validation;
using Business.Repositories.StudentRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentRepository;
using Entities.Dtos;

namespace Business.Repositories.StudentRepository
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentValidator))]
        //[RemoveCacheAspect("IStudentService.Get")]

        public async Task<IResult> Add(Student student)
        {
            try
            {
                var result = await _studentDal.Get(p => p.Number == student.Number);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentDal.Add(student);
                return new SuccessResult(StudentMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentValidator))]
        //[RemoveCacheAspect("IStudentService.Get")]

        public async Task<IResult> Update(Student student)
        {
            try
            {
                var result = await _studentDal.Get(p => p.Number == student.Number && p.FirstName == student.FirstName && p.LastName == student.LastName && p.Email == student.Email && p.DepartmentId == student.DepartmentId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentDal.Update(student);
                return new SuccessResult(StudentMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IStudentService.Get")]

        public async Task<IResult> Delete(Student student)
        {
            try
            {
                await _studentDal.Delete(student);
                return new SuccessResult(StudentMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StudentListDto>>> GetList()
        {
            return new SuccessDataResult<List<StudentListDto>>(await _studentDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Student>> GetById(int id)
        {
            return new SuccessDataResult<Student>(await _studentDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<StudentListDto>>> GetListByDepartmentId(int id)
        {
            return new SuccessDataResult<List<StudentListDto>>(await _studentDal.GetListByDepartmentId(id));
        }

        public async Task<IDataResult<List<CompanyListDto>>> GetCompanyListByStudentId(int studentId)
        {
            return new SuccessDataResult<List<CompanyListDto>>(await _studentDal.GetCompanyListByStudentId(studentId));
        }
    }
}