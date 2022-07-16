using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest2Application.Models;
using WebRest2Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebRest2Application.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {           
            var result = _productService.GetAll();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(new {status = true, data = result }); 
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.Create(product);
            return Ok(new { msg = "新增成功" , data = product });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
            _productService.Update(product); 
            return Ok(new { msg = "修改成功" , data = product});
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if(product == null)
            {
                return NotFound("找不到資源");
            }
            _productService.Delete(product);
            return Ok(new { msg = "刪除成功"});            
        }
    }
}
