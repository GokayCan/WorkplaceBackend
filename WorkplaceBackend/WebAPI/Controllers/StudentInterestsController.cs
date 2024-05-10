using Business.Repositories.StudentInterestRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInterestsController : ControllerBase
    {
        private readonly IStudentInterestService _studentInterestService;

        public StudentInterestsController(IStudentInterestService studentInterestService)
        {
            _studentInterestService = studentInterestService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StudentInterest studentInterest)
        {
            var result = await _studentInterestService.Add(studentInterest);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StudentInterest studentInterest)
        {
            var result = await _studentInterestService.Update(studentInterest);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StudentInterest studentInterest)
        {
            var result = await _studentInterestService.Delete(studentInterest);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentInterestService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentInterestService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByInterestId(int id)
        {
            var result = await _studentInterestService.GetListDtoByInterestId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDto()
        {
            var result = await _studentInterestService.GetListDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByStudentId(int id)
        {
            var result = await _studentInterestService.GetListDtoByStudentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
