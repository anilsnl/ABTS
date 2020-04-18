using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABTS.API.Models;
using ABTS.BLL.Abstract;
using ABTS.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABTS.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager _productManager)
        {
            this._productManager = _productManager;
        }
        /// <summary>
        /// Get products related to given conditions.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("GetProductList")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductList([FromQuery]ProductListModel model)
        {
            List<Product> response = await _productManager.GetProductList(columnName: model.columnName, page: model.page, pageSize: model.pageSize, isDesc: model.isDesc).ToListAsync();
            return Ok(response);
        }

        [HttpGet("GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var response = await _productManager.GetAsync(a => a.ProductId == id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpPost("PostProduct")]
        public async Task<IActionResult> PostProduct([FromBody]Product product)
        {
            var data = await _productManager.AddAsync(product);
            if (data)
            {
                return Ok("Product added");
            }
            else
            {
                return BadRequest("Product could not be added.");
            }
        }
        [HttpPut("PutProduct")]
        public async Task<IActionResult> PuttProduct([FromBody]Product product)
        {
            var data = await _productManager.UpdateAndGetAsync(product);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Product could not be added.");
            }
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody]int id)
        {
            var data = await _productManager.DeleteAsync(new Product { ProductId = (short)id});
            if (data)
            {
                return Ok("Product deleted");
            }
            else
            {
                return BadRequest("Product could not be deleted.");
            }
        }
    }
}