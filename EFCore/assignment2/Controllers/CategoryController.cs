using Microsoft.AspNetCore.Mvc;
using assignment2.Services;
using assignment2.DTOs.Categories;

namespace assignment2.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpPost("category-adding")]
        public AddCategoryResponse? Add([FromBody] AddCategory addModel)
        {
            return _categoryService.Add(addModel);
        }

        [HttpGet("all-category-list")]
        public ActionResult<IEnumerable<AddCategoryResponse>> GetAll()
        {
            try
            {
                var categories = _categoryService.GetAll(x => true);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpGet("category-list/{id}")]
        public ActionResult<AddCategoryResponse> Get(int id)
        {
            try
            {
                var category = _categoryService.Get(g => g.Id == id, id);

                return category != null ? Ok(category) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpDelete("list-deletion/{id}")]
        public ActionResult<AddCategoryResponse> Delete(int id)
        {
            try
            {
                var isSucceeded = _categoryService.Delete(id);

                return isSucceeded ? NoContent() : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpPut("list-update/{id}")]
        public ActionResult<AddCategoryResponse> Update(int id, [FromBody] AddCategory updateModel)
        {
            if (updateModel == null) return BadRequest();

            try
            {
                var updatedCategory = _categoryService.Update(id, updateModel);

                return updatedCategory != null ? Ok(updatedCategory) : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }
    }
}