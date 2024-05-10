using Business.Repositories.CompanyRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Company company)
        {
            var result = await _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExcelToDB()
        {
            var result = await _companyService.ExcelToDB();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Company company)
        {
            var result = await _companyService.Update(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> ChangeData()
        //{
        //    var result = await _companyService.ChangeData();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Company company)
        {
            var result = await _companyService.Delete(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _companyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _companyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{sectorId}")]
        public async Task<IActionResult> GetListBySectorId(int sectorId)
        {
            var result = await _companyService.GetListBySectorId(sectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
