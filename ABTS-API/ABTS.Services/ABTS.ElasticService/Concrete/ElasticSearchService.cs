using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using ABTS.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ABTS.ElasticService.Concrete
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly Helper _helper;
        private readonly IConfiguration _configuration;
        public ElasticSearchService(IConfiguration _configuration)
        {
            _helper = new Helper();
            this._configuration = _configuration;
        }
        public bool CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList)
        {
            string productsIndexName = _configuration["Elastic:Indexes:Product"].ToString(); ;
            string categoriesIndexName = _configuration["Elastic:Indexes:Category"].ToString(); ;
            string suppliersIndexName = _configuration["Elastic:Indexes:Product"].ToString(); ;
            var productSchema = productList.Select(a => 
                new ProductSchema()
                {
                    CategoryId = a.CategoryId.ToString(),
                    ProductId = a.ProductId.ToString(),
                    ProductName = a.ProductName,
                    SupplierId = a.SupplierId.ToString()
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
            
           
            if (!_helper.IndexExists(productsIndexName)&& _helper.CreateIndexProduct(productsIndexName))
            {
                var resultproducts = _helper.AddManyProduct(productsIndexName, productSchema);
            }
            if (!_helper.IndexExists(categoriesIndexName)&& _helper.CreateIndexCategories(categoriesIndexName))
            {
                var resultcategories = _helper.AddManyCategory(categoriesIndexName, categorySchema);
            }
            if (!_helper.IndexExists(suppliersIndexName)&& _helper.CreateIndexSuppliers(suppliersIndexName))
            {
                var resultsuppliers = _helper.AddManySupplier(suppliersIndexName, supplierSchema);
            }
            return true;
        }

    }

}
