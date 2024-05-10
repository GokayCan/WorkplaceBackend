using Business.Repositories.StudentLessonRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class StudentLessonController : ControllerBase
    {
        private readonly IStudentLessonService _studentLessonService;

        public StudentLessonController(IStudentLessonService studentLessonService)
        {
            _studentLessonService = studentLessonService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StudentLesson studentLesson)
        {
            var result = await _studentLessonService.Add(studentLesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StudentLesson studentLesson)
        {
            var result = await _studentLessonService.Update(studentLesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StudentLesson studentLesson)
        {
            var result = await _studentLessonService.Delete(studentLesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentLessonService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDto()
        {
            var result = await _studentLessonService.GetListDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("[action]/{studentId}")]
        public async Task<IActionResult> GetListByStudentId(int studentId)
        {
            var result = await _studentLessonService.GetListByStudentId(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentLessonService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
