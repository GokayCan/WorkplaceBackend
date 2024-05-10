using Business.Repositories.CompanyResponsibleRepository;
using Business.Repositories.CompanyStaffRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyResponsiblesController : ControllerBase
    {
        private readonly ICompanyResponsibleService _companyResponsibleService;

        public CompanyResponsiblesController(ICompanyResponsibleService companyResponsibleService)
        {
            _companyResponsibleService = companyResponsibleService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleService.Add(companyResponsible);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleService.Update(companyResponsible);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CompanyResponsible companyResponsible)
        {
            var result = await _companyResponsibleService.Delete(companyResponsible);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _companyResponsibleService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByCompanyId(int id)
        {
            var result = await _companyResponsibleService.GetListDtoByCompanyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _companyResponsibleService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
