using Business.Repositories.StudentProgrammingRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProgrammingsController : ControllerBase
    {
        private readonly IStudentProgrammingService _studentProgrammingService;

        public StudentProgrammingsController(IStudentProgrammingService studentProgrammingService)
        {
            _studentProgrammingService = studentProgrammingService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StudentProgramming studentProgramming)
        {
            var result = await _studentProgrammingService.Add(studentProgramming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StudentProgramming studentProgramming)
        {
            var result = await _studentProgrammingService.Update(studentProgramming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StudentProgramming studentProgramming)
        {
            var result = await _studentProgrammingService.Delete(studentProgramming);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentProgrammingService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentProgrammingService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDto()
        {
            var result = await _studentProgrammingService.GetListDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByProgrammingId(int id)
        {
            var result = await _studentProgrammingService.GetListDtoByProgrammingId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByStudentId(int id)
        {
            var result = await _studentProgrammingService.GetListDtoByStudentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
