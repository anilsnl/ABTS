using ABTS.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Abstract
{
    public interface IElasticSearchService
    {
        Task<bool> CreateAllIndexes(List<Product> productList, List<Category> categoryList, List<Supplier> supplierList);
    }
}
