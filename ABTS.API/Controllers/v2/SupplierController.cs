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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierManager _supplierManager;

        public SupplierController(ISupplierManager supplierManager)
        {
            _supplierManager = supplierManager;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            var response = await _supplierManager.GetListAsync();
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
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _supplierManager.GetAsync(a => a.SupplierId == id);
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
        public async Task<IActionResult> Post([FromBody]Supplier supplier)
        {
            var data = await _supplierManager.AddAsync(supplier);
            if (data)
            {
                return Ok("Supplier added");
            }
            else
            {
                return BadRequest("Supplier could not be added.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Supplier supplier)
        {
            var data = await _supplierManager.UpdateAndGetAsync(supplier);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Supplier could not be added.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var data = await _supplierManager.DeleteAsync(new Supplier { SupplierId = (short)id });
            if (data)
            {
                return Ok("Supplier deleted");
            }
            else
            {
                return BadRequest("Supplier could not be deleted.");
            }
        }
    }
}