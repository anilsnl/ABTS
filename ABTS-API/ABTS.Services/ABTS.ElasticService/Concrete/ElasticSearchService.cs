using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using ABTS.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Concrete
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly Helper _helper;
        private readonly IConfiguration _configuration;
        public ElasticSearchService(IConfiguration _configuration, Helper helper)
        {
            _helper = helper;
            this._configuration = _configuration;
        }
        public async Task<bool> CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList)
        {
            string productsIndexName = _configuration["Elastic:Indexes:Product"].ToString(); ;
            string categoriesIndexName = _configuration["Elastic:Indexes:Category"].ToString(); ;
            string suppliersIndexName = _configuration["Elastic:Indexes:Product"].ToString(); ;
            var productSchema = productList.Select(a =>
                new ProductSchema()
                {
                    CategoryId = a.CategoryId.GetValueOrDefault(),
                    ProductId = a.ProductId,
                    ProductName = a.ProductName,
                    SupplierId = a.SupplierId.GetValueOrDefault()
                });
            var categorySchema = categoryList.Select(a => new CategorySchema()
            {
                CategoryId = a.CategoryId.ToString(),
                CategoryName = a.CategoryName.ToString()
            });
            var supplierSchema = supplierList.Select(a => new SupplierSchema()
            {
                SupplierId = a.SupplierId.ToString(),
                City = a.City,
                CompanyName = a.CompanyName
            });
            
            var resultproducts = await _helper.AddManyProductAsync(productsIndexName, productSchema);
            var resultcategories = await _helper.AddManyCategoryAsync(categoriesIndexName, categorySchema);
            var resultsuppliers = await _helper.AddManySupplierAsync(suppliersIndexName, supplierSchema);

            return resultcategories && resultproducts && resultsuppliers;
        }

    }

}
