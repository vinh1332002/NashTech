using Microsoft.AspNetCore.Mvc;
using assignment1.Models.RequestModels;
using assignment1.Services;


namespace assignment1.Controllers
{
    [Route("api/v1/[controller]")]
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskServices _taskServices;

        public TasksController(ILogger<TasksController> logger, ITaskServices taskServices)
        {
            _logger = logger;
            _taskServices = taskServices;
        }

        [HttpGet("GetAll")]

        public List<NewTaskRequestModel> GetAll()
        {
            return _taskServices.GetAll();
        }

        [HttpGet("GetOne")]
        public IActionResult GetOne(int index)
        {
            try
            {
                var data = _taskServices.GetOne(index);

                if (data == null)
                {
                    return BadRequest("some message");
                };

                if (index < 0)
                {
                    return BadRequest("some message");
                }

                return new JsonResult(new NewTaskRequestModel
                {
                    Title = data.Title,
                    IsCompleted = data.IsCompleted
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpPut("Update")]

        public IActionResult UpdateList(int index, NewTaskRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("some message");
            };

            try
            {
                var data = _taskServices.GetOne(index);

                if (data == null)
                {
                    return BadRequest("some message");
                };
                data.UniqueId = model.UniqueId;
                data.Title = model.Title;
                data.IsCompleted = model.IsCompleted;

                var result = _taskServices.Update(index, data);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpDelete("Delete")]

        public IActionResult DeleteList(int index)
        {
            try
            {
                var data = _taskServices.GetOne(index);

                if (data == null)
                {
                    return BadRequest("some message");
                };

                var result = _taskServices.Delete(index);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpPost("Add")]

        public IActionResult Add([FromBody] NewTaskRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var data = new NewTaskRequestModel
                {
                    UniqueId = Guid.NewGuid(),
                    Title = model.Title,
                    IsCompleted = model.IsCompleted
                };

                var result = _taskServices.Create(model);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpPost("AddMultiple")]
        public IActionResult AddMultiple([FromBody] List<NewTaskRequestModel> persons)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var data = persons.Select(p =>
                    new
                    {
                        p.Title,
                        p.IsCompleted,
                    }
                );

                var result = _taskServices.AddList(persons);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpPost("DeleteMultiple")]
        public IActionResult DeleteMultiple(List<Guid> indexes)
        {
            _taskServices.DeleteMulti(indexes);
            return Ok();
        }
    }
}