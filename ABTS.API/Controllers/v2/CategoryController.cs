using ABTS.BLL.Abstract;
using ABTS.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            var response = await _categoryManager.GetListAsync();
            if (response == null || !response.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var response = await _categoryManager.GetAsync(a => a.CategoryId == id);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category category)
        {
            var data = await _categoryManager.AddAsync(category);
            if (data)
            {
                return Ok("Category added");
            }
            else
            {
                return BadRequest("Category could not be added.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Category category)
        {
            var data = await _categoryManager.UpdateAndGetAsync(category);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Category could not be added.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var data = await _categoryManager.DeleteAsync(new Category { CategoryId = (short)id });
            if (data)
            {
                return Ok("Category deleted");
            }
            else
            {
                return BadRequest("Category could not be deleted.");
            }
        }
    }
}