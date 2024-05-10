using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StudentProgrammingRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StudentProgrammingRepository.Validation;
using Business.Repositories.StudentProgrammingRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentProgrammingRepository;
using Entities.Dtos;

namespace Business.Repositories.StudentProgrammingRepository
{
    public class StudentProgrammingManager : IStudentProgrammingService
    {
        private readonly IStudentProgrammingDal _studentProgrammingDal;

        public StudentProgrammingManager(IStudentProgrammingDal studentProgrammingDal)
        {
            _studentProgrammingDal = studentProgrammingDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentProgrammingValidator))]
        //[RemoveCacheAspect("IStudentProgrammingService.Get")]

        public async Task<IResult> Add(StudentProgramming studentProgramming)
        {
            try
            {
                var result = await _studentProgrammingDal.Get(p => p.ProgrammingId == studentProgramming.ProgrammingId && p.StudentId == studentProgramming.StudentId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentProgrammingDal.Add(studentProgramming);
                return new SuccessResult(StudentProgrammingMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentProgrammingValidator))]
        //[RemoveCacheAspect("IStudentProgrammingService.Get")]

        public async Task<IResult> Update(StudentProgramming studentProgramming)
        {
            try
            {
                var result = await _studentProgrammingDal.Get(p => p.ProgrammingId == studentProgramming.ProgrammingId && p.StudentId == studentProgramming.StudentId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentProgrammingDal.Update(studentProgramming);
                return new SuccessResult(StudentProgrammingMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IStudentProgrammingService.Get")]

        public async Task<IResult> Delete(StudentProgramming studentProgramming)
        {
            try
            {
                var result = await _studentProgrammingDal.Get(p => p.Id == studentProgramming.Id);
                result.IsActive = false;
                await _studentProgrammingDal.SoftDelete(result);
                return new SuccessResult(StudentProgrammingMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StudentProgramming>>> GetList()
        {
            return new SuccessDataResult<List<StudentProgramming>>(await _studentProgrammingDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StudentProgramming>> GetById(int id)
        {
            return new SuccessDataResult<StudentProgramming>(await _studentProgrammingDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<StudentProgrammingListDto>>> GetListDto()
        {
            return new SuccessDataResult<List<StudentProgrammingListDto>>(await _studentProgrammingDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<List<StudentProgrammingListDto>>> GetListDtoByProgrammingId(int id)
        {
            return new SuccessDataResult<List<StudentProgrammingListDto>>(await _studentProgrammingDal.GetListDtoByProgrammingId(id));
        }

        public async Task<IDataResult<List<StudentProgrammingListDto>>> GetListDtoByStudentId(int id)
        {
            return new SuccessDataResult<List<StudentProgrammingListDto>>(await _studentProgrammingDal.GetListDtoByStudentId(id));
        }
    }
}