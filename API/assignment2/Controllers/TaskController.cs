using Microsoft.AspNetCore.Mvc;
using assignment2.Filter;
using assignment2.Models;
using assignment2.Services;

namespace assignment2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskServices _taskServices;

        public TaskController(ILogger<TaskController> logger, ITaskServices taskServices)
        {
            _logger = logger;
            _taskServices = taskServices;
        }


        [HttpGet]
        [Route("all-list-pagnition")]
        public IActionResult GetListFilter([FromQuery] OwnerParameters ownerParameters)
        {
            var owners = _taskServices.GetPagnition(ownerParameters);
            return Ok(owners);
        }

        [HttpPut]
        [Route("list-update")]

        public IActionResult UpdateList(Guid index, NewTaskRequestModel model)
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

                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Gender = model.Gender;
                data.DateOfBirth = model.DateOfBirth;
                data.BirthPlace = model.BirthPlace;

                var result = _taskServices.Update(index, data);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpDelete]
        [Route("list-deletion")]

        public IActionResult DeleteList(Guid index)
        {
            try
            {
                var data = _taskServices.GetOne(index);

                if (data == null)
                {
                    return BadRequest("some message");
                };

                var result = _taskServices.Delete(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpPost]
        [Route("list-adding")]

        public IActionResult Add([FromBody] NewTaskRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var data = new NewTaskRequestModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    BirthPlace = model.BirthPlace
                };

                var result = _taskServices.Create(model);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "some message: " + ex);
            }
        }

        [HttpGet]
        [Route("filter-list")]
        public List<NewTaskRequestModel> GetFilterList(string firstName, string lastName, string gender, string birthPlace)
        {
            return _taskServices.FilterList(firstName, lastName, gender, birthPlace);
        }
    }
}