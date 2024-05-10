using Business.Repositories.ProgrammingRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingsController : ControllerBase
    {
        private readonly IProgrammingService _programmingService;

        public ProgrammingsController(IProgrammingService programmingService)
        {
            _programmingService = programmingService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Programming programming)
        {
            var result = await _programmingService.Add(programming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Programming programming)
        {
            var result = await _programmingService.Update(programming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Programming programming)
        {
            var result = await _programmingService.Delete(programming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _programmingService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _programmingService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
