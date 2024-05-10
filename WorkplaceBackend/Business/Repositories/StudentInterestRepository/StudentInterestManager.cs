using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StudentInterestRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StudentInterestRepository.Validation;
using Business.Repositories.StudentInterestRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentInterestRepository;
using Entities.Dtos;

namespace Business.Repositories.StudentInterestRepository
{
    public class StudentInterestManager : IStudentInterestService
    {
        private readonly IStudentInterestDal _studentInterestDal;

        public StudentInterestManager(IStudentInterestDal studentInterestDal)
        {
            _studentInterestDal = studentInterestDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentInterestValidator))]
        //[RemoveCacheAspect("IStudentInterestService.Get")]

        public async Task<IResult> Add(StudentInterest studentInterest)
        {
            try
            {
                var result = await _studentInterestDal.Get(p => p.InterestId == studentInterest.InterestId && p.StudentId == studentInterest.StudentId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentInterestDal.Add(studentInterest);
                return new SuccessResult(StudentInterestMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StudentInterestValidator))]
        //[RemoveCacheAspect("IStudentInterestService.Get")]

        public async Task<IResult> Update(StudentInterest studentInterest)
        {
            try
            {
                var result = await _studentInterestDal.Get(p => p.InterestId == studentInterest.InterestId && p.StudentId == studentInterest.StudentId);

                if (result != null)
                {
                    return new ErrorResult("Bu Kayýt Zaten Mevcut");
                }

                await _studentInterestDal.Update(studentInterest);
                return new SuccessResult(StudentInterestMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IStudentInterestService.Get")]

        public async Task<IResult> Delete(StudentInterest studentInterest)
        {
            try
            {
                var result = await _studentInterestDal.Get(p => p.Id == studentInterest.Id);
                result.IsActive = false;
                await _studentInterestDal.SoftDelete(result);
                return new SuccessResult(StudentInterestMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StudentInterest>>> GetList()
        {
            return new SuccessDataResult<List<StudentInterest>>(await _studentInterestDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StudentInterest>> GetById(int id)
        {
            return new SuccessDataResult<StudentInterest>(await _studentInterestDal.Get(p => p.Id == id));
        }

        public async Task<IDataResult<List<StudentInterestListDto>>> GetListDtoByInterestId(int id)
        {
            return new SuccessDataResult<List<StudentInterestListDto>>(await _studentInterestDal.GetListDtoByInterestId(id));
        }

        public async Task<IDataResult<List<StudentInterestListDto>>> GetListDtoByStudentId(int id)
        {
            return new SuccessDataResult<List<StudentInterestListDto>>(await _studentInterestDal.GetListDtoByStudentId(id));
        }

        public async Task<IDataResult<List<StudentInterestListDto>>> GetListDto()
        {
            return new SuccessDataResult<List<StudentInterestListDto>>(await _studentInterestDal.GetListDto());
        }
    }
}