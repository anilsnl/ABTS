using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using ABTS.RedisService.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IElasticSearchService _elasticSearch;
        private readonly IProductElasticService _productElasticService;
        private readonly IRedisService _redisService;
        public SearchController(IElasticSearchService _elasticSearch,
            IProductElasticService _productElasticService,
            IRedisService redisService)
        {
            this._elasticSearch = _elasticSearch;
            this._productElasticService = _productElasticService;
            this._redisService = redisService;
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