using ABTS.BLL.Abstract;
using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABTS.RedisService.Abstract;

namespace ABTS.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ISupplierManager _supplierManager;
        private readonly IElasticSearchService _elasticSearch;
        private readonly IProductElasticService _productElasticService;
        private IRedisService _redisService;
        public SearchController(IProductManager _productManager, 
            IElasticSearchService _elasticSearch, ICategoryManager _categoryManager, ISupplierManager _supplierManager,
            IProductElasticService _productElasticService,
            IRedisService redisService)
        {
            this._productManager = _productManager;
            this._categoryManager = _categoryManager;
            this._supplierManager = _supplierManager;
            this._elasticSearch = _elasticSearch;
            this._productElasticService = _productElasticService;
            this._redisService = redisService;
        }

        [HttpGet("Configure")]
        public async Task<ActionResult<string>> Configure()
        {
            var products = await _productManager.GetListAsync().Result.ToListAsync();
            var categories = await _categoryManager.GetListAsync().Result.ToListAsync();
            var suppliers = await _supplierManager.GetListAsync().Result.ToListAsync();

            var test = _elasticSearch.CreateAllIndexes(products, categories, suppliers);
            return Ok("Created");
        }

        [HttpGet("GetProductByName")]
        public async Task<ActionResult<IEnumerable<ProductSchema>>> GetProductByName(string key)
        {

            var response =
                await _redisService.GetAndSetAsync(key, () => _productElasticService.GetProductsByName(key));
            if (response != null && response.Any())
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Could not be found");
            }
        }

    }
}