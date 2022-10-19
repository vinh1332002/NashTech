using Microsoft.AspNetCore.Mvc;
using assignment1.DTOs;
using assignment1.Services;

namespace assignment1.Controllers
{
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost("list-adding")]
        public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
        {
            return _studentService.Create(addRequest);
        }

        [HttpGet("all-list")]
        public ActionResult<IEnumerable<AddStudentResponse>> GetAll()
        {
            try
            {
                var students = _studentService.GetAll(g => true);

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpGet("one-list/{id}")]
        public ActionResult<AddStudentResponse> Get(int id)
        {
            try
            {
                var student = _studentService.Get(g => g.Id == id, id);

                return student != null ? Ok(student) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpPut("list-update/{id}")]
        public ActionResult<AddStudentResponse> Update(int id, [FromBody] AddStudentRequest updateModel)
        {
            if (updateModel == null) return BadRequest();

            try
            {
                var updatedStudent = _studentService.Update(id, updateModel);

                return updatedStudent != null ? Ok(updatedStudent) : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpDelete("list-deletion/{id}")]
        public ActionResult<AddStudentResponse> Delete(int id)
        {
            try
            {
                var isSucceeded = _studentService.Delete(id);

                return isSucceeded ? NoContent() : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }
    }
}