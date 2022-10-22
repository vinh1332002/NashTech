using Microsoft.AspNetCore.Mvc;
using assignment2.Services;
using assignment2.DTOs.Products;

namespace assignment2.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost("product-adding")]
        public AddProductResponse? Add([FromBody] AddProduct addModel)
        {
            return _productService.Add(addModel);
        }

        [HttpGet("all-product-list")]
        public ActionResult<IEnumerable<AddProductResponse>> GetAll()
        {
            try
            {
                var products = _productService.GetAll(x => true);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpGet("product-list/{id}")]
        public ActionResult<AddProductResponse> Get(int id)
        {
            try
            {
                var product = _productService.Get(g => g.ProductId == id, id);

                return product != null ? Ok(product) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpDelete("list-deletion/{id}")]
        public ActionResult<AddProductResponse> Delete(int id)
        {
            try
            {
                var isSucceeded = _productService.Delete(id);

                return isSucceeded ? NoContent() : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }

        [HttpPut("list-update/{id}")]
        public ActionResult<AddProductResponse> Update(int id, [FromBody] AddProduct updateModel)
        {
            if (updateModel == null) return BadRequest();

            try
            {
                var updatedStudent = _productService.Update(id, updateModel);

                return updatedStudent != null ? Ok(updatedStudent) : StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected Error!" + ex);
            }
        }
    }
}