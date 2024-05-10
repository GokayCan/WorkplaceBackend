using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.DepartmentRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.DepartmentRepository.Validation;
using Business.Repositories.DepartmentRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.DepartmentRepository;
using Entities.Dtos;

namespace Business.Repositories.DepartmentRepository
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(DepartmentValidator))]
        //[RemoveCacheAspect("IDepartmentService.Get")]

        public async Task<IResult> Add(Department department)
        {
            try
            {
                await _departmentDal.Add(department);
                return new SuccessResult(DepartmentMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(DepartmentValidator))]
        //[RemoveCacheAspect("IDepartmentService.Get")]

        public async Task<IResult> Update(Department department)
        {
            try
            {
                await _departmentDal.Update(department);
                return new SuccessResult(DepartmentMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IDepartmentService.Get")]

        public async Task<IResult> Delete(Department department)
        {
            try
            {
                var result = await _departmentDal.Get(p => p.Id == department.Id);
                result.IsActive = false;
                await _departmentDal.SoftDelete(result);
                return new SuccessResult(DepartmentMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<DepartmentListDto>>> GetList()
        {
            return new SuccessDataResult<List<DepartmentListDto>>(await _departmentDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<Department>> GetById(int id)
        {
            return new SuccessDataResult<Department>(await _departmentDal.Get(p => p.Id == id));
        }
    }
}