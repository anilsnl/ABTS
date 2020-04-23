using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            try
            {
                var searchResponse = await _elasticClient.SearchAsync<ProductSchema>(s => s
                                     .Index(indexName)
                                     .Suggest(su => su
                                          .Completion("suggestions", c => c
                                               .Field(f => f.ProductName)
                                               .Prefix(keyword)
                                               .Fuzzy(f => f
                                                   .Fuzziness(Fuzziness.Auto)
                                               )
                                               .Size(5))
                                             ));

                var suggests = from suggest in searchResponse.Suggest["suggestions"]
                               from option in suggest.Options
                               select option.Source;
                return suggests;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
