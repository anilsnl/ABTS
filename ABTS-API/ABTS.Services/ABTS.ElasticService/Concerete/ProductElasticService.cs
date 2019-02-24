using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Concerete
{
    public class ProductElasticService : IProductElasticService
    {
        private readonly ElasticClient _elasticClient;
        private readonly IConfiguration _configuration;
        private const string indexName = "abts_products";
        public ProductElasticService(IConfiguration configuration)
        {
            _configuration = configuration;
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(_configuration.GetConnectionString("ELASTIC"))));
        }

        public async Task<IEnumerable<ProductSchema>> GetProductsByName(string keyword)
        {
            var searchResponseName = await _elasticClient.SearchAsync<ProductSchema>(s => s
                                 .Index(indexName)
                                 .Type("productschema")
                                 .Query(q => q.QueryString(qs => qs.Fields(x => x.Field(t => t.ProductName)).Query(keyword + "*"))));

            var suggests = from suggest in searchResponseName.Hits
                           select new ProductSchema
                           {
                               CategoryId = suggest.Source.CategoryId,
                               SupplierId = suggest.Source.SupplierId,
                               ProductName = suggest.Source.ProductName,
                               ProductId=suggest.Source.ProductId
                           };
            return suggests;
        }
    }
}
