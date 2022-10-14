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

        [HttpPost("v1-new")]
        public int CreateANewTask([FromBody] NewTaskRequestModel requestModel)
        {
            var newID = 1;
            return newID;
        }

        [HttpPost("v2-new")]
        public IActionResult CreateANewTaskV2([FromBody] NewTaskRequestModel requestModel)
        {
            if (string.IsNullOrWhiteSpace(requestModel.Title))
            {
                return BadRequest("some message");
            }
            requestModel.Title = requestModel.Title.Trim();
            if (requestModel.Title.Length < 2 || requestModel.Title.Length > 15) return BadRequest("some message");

            try
            {
                var newID = 1;

                return Ok(newID);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }
        [HttpGet("GetAll")]

        public IEnumerable<NewTaskRequestModel> GetAll()
        {
            var data = _taskServices.GetAll();

            return from item in data
                   select new NewTaskRequestModel
                   {
                       Title = item.Title,
                       IsCompleted = item.IsCompleted
                   };
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

        public IActionResult Add(NewTaskRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var data = new NewTaskRequestModel
                {
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
        //Em vẫn chưa tìm đc cách làm bài 7 kịp ạ, em vẫn nộp cho đúng hạn ạ
    }
}