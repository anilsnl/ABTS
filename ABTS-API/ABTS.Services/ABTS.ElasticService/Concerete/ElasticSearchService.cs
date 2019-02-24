using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Schema;
using ABTS.Entities.Concerete;
using System.Collections.Generic;
using System.Linq;

namespace ABTS.ElasticService.Concerete
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly Helper _helper;
        public ElasticSearchService()
        {
            _helper = new Helper();
        }
        public bool CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList)
        {
            string productsIndexName = "abts_products";
            string categoriesIndexName = "abts_categories";
            string suppliersIndexName = "abts_suppliers";
            List<ProductSchema> productSchema = new List<ProductSchema>();
            List<CategorySchema> categorySchema = new List<CategorySchema>();
            List<SupplierSchema> supplierSchema = new List<SupplierSchema>();
            foreach (var item in productList)
            {
                productSchema.Add(new ProductSchema { CategoryId = item.CategoryId.GetValueOrDefault().ToString(), ProductId = item.ProductId.ToString(), SupplierId = item.SupplierId.GetValueOrDefault().ToString(), ProductName = item.ProductName });
            }
            foreach (var item in categoryList)
            {
                categorySchema.Add(new CategorySchema { CategoryId=item.CategoryId.ToString(),CategoryName=item.CategoryName});
            }
            foreach (var item in supplierList)
            {
                supplierSchema.Add(new SupplierSchema {SupplierId=item.SupplierId.ToString(),City=item.City,CompanyName=item.CompanyName});
            }

            if (!_helper.IndexExists(productsIndexName))
            {
                if (_helper.CreateIndexProduct(productsIndexName))
                {
                    var resultproducts = _helper.AddManyProduct(productsIndexName, productSchema);
                }
            }
            if (!_helper.IndexExists(categoriesIndexName))
            {
                if (_helper.CreateIndexCategories(categoriesIndexName))
                {
                    var resultcategories = _helper.AddManyCategory(categoriesIndexName, categorySchema);
                }
            }
            if (!_helper.IndexExists(suppliersIndexName))
            {
                if (_helper.CreateIndexSuppliers(suppliersIndexName))
                {
                    var resultsuppliers = _helper.AddManySupplier(suppliersIndexName, supplierSchema);
                }
            }
            return true;
        }

    }

}
