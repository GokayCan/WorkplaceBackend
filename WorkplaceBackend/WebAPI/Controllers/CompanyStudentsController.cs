using Business.Repositories.CompanyResponsibleRepository;
using Business.Repositories.CompanyStudentRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyStudentsController : ControllerBase
    {
        private readonly ICompanyStudentService _companyStudentService;

        public CompanyStudentsController(ICompanyStudentService companyStudentService)
        {
            _companyStudentService = companyStudentService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CompanyStudent companyStudent)
        {
            var result = await _companyStudentService.Add(companyStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CompanyStudent companyStudent)
        {
            var result = await _companyStudentService.Update(companyStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CompanyStudent companyStudent)
        {
            var result = await _companyStudentService.Delete(companyStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _companyStudentService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByCompanyId(int id)
        {
            var result = await _companyStudentService.GetListDtoByCompanyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _companyStudentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
