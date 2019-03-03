using ABTS.Entities.Concrete;
using System.Collections.Generic;

namespace ABTS.ElasticService.Abstract
{
    public interface IElasticSearchService
    {
        bool CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList);
    }
}
