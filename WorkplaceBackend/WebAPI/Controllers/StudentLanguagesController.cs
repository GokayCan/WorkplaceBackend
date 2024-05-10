using Business.Repositories.StudentLanguageRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLanguagesController : ControllerBase
    {
        private readonly IStudentLanguageService _studentLanguageService;

        public StudentLanguagesController(IStudentLanguageService studentLanguageService)
        {
            _studentLanguageService = studentLanguageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StudentLanguage studentLanguage)
        {
            var result = await _studentLanguageService.Add(studentLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StudentLanguage studentLanguage)
        {
            var result = await _studentLanguageService.Update(studentLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StudentLanguage studentLanguage)
        {
            var result = await _studentLanguageService.Delete(studentLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentLanguageService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentLanguageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDto()
        {
            var result = await _studentLanguageService.GetListDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByLanguageId(int id)
        {
            var result = await _studentLanguageService.GetListDtoByLanguageId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetListDtoByStudentId(int id)
        {
            var result = await _studentLanguageService.GetListDtoByStudentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
