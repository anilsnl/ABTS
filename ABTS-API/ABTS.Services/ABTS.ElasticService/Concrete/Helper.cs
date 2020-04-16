using ABTS.ElasticService.Schema;
using ABTS.Entities.Abstract;
using ABTS.Entities.Concrete;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Concrete
{
    public class Helper
    {
        private readonly ElasticClient _elasticClient;
        public Helper(string connectionSettings)
        {
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(connectionSettings)));
        }
        public Helper()
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://192.168.204.128:9200"));
            _elasticClient = new ElasticClient(connectionSettings);
        }

        public async Task<bool> AddManyProductAsync(string indexName, IEnumerable<ProductSchema> products)
        {
            var existResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            if (existResponse.Exists)
            {
                await _elasticClient.Indices.DeleteAsync(indexName);
            }
            await _elasticClient.Indices.CreateAsync(indexName, c => c.Map<ProductSchema>(a => a.AutoMap().Properties(p=>p.Completion(cc=>cc.Name(pn=>pn.ProductName)))));

            var res = await _elasticClient.IndexManyAsync<ProductSchema>(products, indexName);
            return res.IsValid;
        }

        public async Task<bool> AddManyCategoryAsync(string indexName, IEnumerable<CategorySchema> categories)
        {
            var existResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            if (!existResponse.Exists)
            {
                await _elasticClient.Indices.CreateAsync(indexName, c => c.Map<CategorySchema>(a => a.AutoMap()));
            }
            var res = await _elasticClient.IndexManyAsync(categories.ToList(), indexName);
            return res.IsValid;
        }
        public async Task<bool> AddManySupplierAsync(string indexName, IEnumerable<SupplierSchema> suppliers)
        {
            var existResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            if (!existResponse.Exists)
            {
                await _elasticClient.Indices.CreateAsync(indexName, c => c.Map<SupplierSchema>(a => a.AutoMap()));
            }
            var res = await _elasticClient.IndexManyAsync(suppliers.ToList(), indexName);
            return res.IsValid;
        }

    }
}
