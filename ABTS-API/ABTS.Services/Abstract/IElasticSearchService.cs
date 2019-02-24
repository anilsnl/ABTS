using ABTS.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTS.ElasticSearchService.Abstract
{
    public interface IElasticSearchService
    {
        bool CreateAllIndexes(List<Products> productList, List<Categories> categoryList, List<Suppliers> supplierList);
    }
}
