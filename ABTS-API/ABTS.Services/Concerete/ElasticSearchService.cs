using ABTS.ElasticSearchService.Abstract;
using ABTS.Entities.Concerete;
using System.Collections.Generic;

namespace ABTS.ElasticSearchService.Concerete
{
    public class ElasticSearchService:IElasticSearchService
    {
        //private readonly Helper _helper;
        public ElasticSearchService()
        {
            //_helper = new Helper();
        }
        public bool CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList)
        {
            //string productsIndexName = "ABTS_PRODUCTS";
            //string categoriesIndexName = "ABTS_CATEGORIES";
            //string suppliersIndexName = "ABTS_SUPPLIERS";

            //if (!_helper.IndexExists(productsIndexName))
            //{
            //    if (_helper.CreateIndexProduct(productsIndexName))
            //        _helper.AddMany(productsIndexName, productList);
            //}
            //if (!_helper.IndexExists(categoriesIndexName))
            //{
            //    if (_helper.CreateIndexProduct(categoriesIndexName))
            //        _helper.AddMany(categoriesIndexName, categoryList);
            //}
            //if (!_helper.IndexExists(suppliersIndexName))
            //{
            //    if (_helper.CreateIndexProduct(suppliersIndexName))
            //        _helper.AddMany(suppliersIndexName, supplierList);
            //}
            return true;
        }
    }
}
