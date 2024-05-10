using Business.Repositories.CompanyStaffRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyStaffsController : ControllerBase
    {
        private readonly ICompanyStaffService _companyStaffService;

        public CompanyStaffsController(ICompanyStaffService companyStaffService)
        {
            _companyStaffService = companyStaffService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CompanyStaff companyStaff)
        {
            var result = await _companyStaffService.Add(companyStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CompanyStaff companyStaff)
        {
            var result = await _companyStaffService.Update(companyStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CompanyStaff companyStaff)
        {
            var result = await _companyStaffService.Delete(companyStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _companyStaffService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByCompanyId(int id)
        {
            var result = await _companyStaffService.GetListDtoByCompanyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _companyStaffService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
