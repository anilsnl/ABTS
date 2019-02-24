using ABTS.BLL.Abstract;
using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ISupplierManager _supplierManager;
        private readonly IElasticSearchService _elasticSearch;


        public SearchController(IProductManager _productManager, IElasticSearchService _elasticSearch, ICategoryManager _categoryManager, ISupplierManager _supplierManager)
        {
            this._productManager = _productManager;
            this._categoryManager = _categoryManager;
            this._supplierManager = _supplierManager;
            this._elasticSearch = _elasticSearch;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetProductList()
        {
            var products = await _productManager.GetListAsync().Result.ToListAsync();
            var categories = await _categoryManager.GetListAsync().Result.ToListAsync();
            var suppliers = await _supplierManager.GetListAsync().Result.ToListAsync();

            var test = _elasticSearch.CreateAllIndexes(products, categories, suppliers);
            return Ok("Created");
        }

        //[HttpGet("{key}")]
        //public async Task<ActionResult<IEnumerable<ProductSchema>>> GetProductByName(string key)
        //{
        //    var response = await _elasticSearch.GetProductsByName(key);
        //    if (response != null && response.Count() > 0)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return NotFound("Could not be found");
        //    }
        //}
    }
}