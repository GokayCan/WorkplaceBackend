using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StaffRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StaffRepository.Validation;
using Business.Repositories.StaffRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StaffRepository;
using Entities.Dtos;
using Business.Repositories.UserRepository;
using ExcelDataReader;

namespace Business.Repositories.StaffRepository
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;
        private readonly IUserService _userService;

        public StaffManager(IStaffDal staffDal, IUserService userService)
        {
            _staffDal = staffDal;
            _userService = userService;
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StaffValidator))]
        //[RemoveCacheAspect("IStaffService.Get")]

        public async Task<IResult> Add(StaffDto staffDto)
        {
            try
            {
                User user = new()
                {
                    Id = 0,
                    FirstName = staffDto.FirstName,
                    LastName = staffDto.LastName,
                    Email = staffDto.Email,
                    Password = staffDto.Password
                };
                var addedUSer = await _userService.AddedUser(user);

                Staff staff = new()
                {
                    Id = 0,
                    UserId = addedUSer.Data.Id,
                    DepartmentId = staffDto.DepartmentId
                };

                await _staffDal.Add(staff);
                return new SuccessResult(StaffMessages.Added);
            }
            catch
            {
                return new ErrorResult("Ekleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[ValidationAspect(typeof(StaffValidator))]
        //[RemoveCacheAspect("IStaffService.Get")]

        public async Task<IResult> Update(StaffDto staffDto)
        {
            try
            {
                var user = await _userService.GetById(staffDto.UserId);

                user.Data.FirstName = staffDto.FirstName;
                user.Data.LastName = staffDto.LastName;
                user.Data.Email = staffDto.Email;
                user.Data.Password = staffDto.Password;

                await _userService.Update(user.Data);

                var staff = await _staffDal.Get(p => p.Id == staffDto.Id);

                staff.DepartmentId = staffDto.DepartmentId;

                await _staffDal.Update(staff);
                return new SuccessResult(StaffMessages.Updated);
            }
            catch
            {
                return new ErrorResult("Güncelleme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[RemoveCacheAspect("IStaffService.Get")]

        public async Task<IResult> Delete(Staff staff)
        {
            try
            {
                await _staffDal.Delete(staff);
                return new SuccessResult(StaffMessages.Deleted);
            }
            catch
            {
                return new ErrorResult("Silme Ýþlemi Baþarýsýz");
            }
        }

        //[SecuredAspect()]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<StaffListDto>>> GetList()
        {
            return new SuccessDataResult<List<StaffListDto>>(await _staffDal.GetListDto());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<StaffDto>> GetById(int id)
        {
            return new SuccessDataResult<StaffDto>(await _staffDal.GetDto(id));
        }

        public async Task<IResult> AddFromExcel(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        var firstName = reader.GetValue(0).ToString().ToLower();
                        var lastName = reader.GetValue(1).ToString().ToLower();
                        var email = reader.GetValue(2).ToString().ToLower();

                        //kýzlýk soyadý ve iki ismi olanlarý ayný zamanda türkçe karakter içerenleri düzelttiðim yer

                        var user = new User
                        {
                            Id = 0,
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            Password = "123456"
                        };
                        var addedUser = await _userService.AddedUser(user);
                        if (addedUser != null)
                        {
                            Staff staff = new()
                            {
                                Id = 0,
                                DepartmentId = 1,
                                UserId = addedUser.Data.Id,
                            };
                            await _staffDal.Add(staff);
                        }
                    }
                }
            }

            return new SuccessResult();
        }

        public async Task<IDataResult<StaffDto>> GetByUserId(int UserId)
        {
            return new SuccessDataResult<StaffDto>(await _staffDal.GetByUserId(UserId));
        }
    }
}