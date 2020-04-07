using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Concrete
{
    public class ProductElasticService : IProductElasticService
    {
        private readonly ElasticClient _elasticClient;
        private readonly IConfiguration _configuration;
        private readonly string indexName;
        public ProductElasticService(IConfiguration configuration)
        {
            _configuration = configuration;
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(_configuration.GetConnectionString("ELASTIC"))));
            indexName = _configuration["Elastic:Indexes:Product"].ToString();
        }

        public async Task<IEnumerable<ProductSchema>> GetProductsByName(string keyword)
        {
            var searchResponseName = await _elasticClient.SearchAsync<ProductSchema>(s => s.SuggestField(a => a.ProductName).Query(a => a.Term(q => q.Value(keyword))));

            var suggests = from suggest in searchResponseName.Hits
                           select suggest.Source;
            return suggests;
        }
    }
}
