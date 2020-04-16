using ABTS.DAL.Abstract;
using ABTS.ElasticService.Abstract;
using ABTS.HangfireService.Abtract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABTS.HangfireService.Concrete
{
    public class ElasticReorganizer : IElasticReorganizer
    {
        private readonly IElasticSearchService _elasticSearchService;
        private readonly IProductDAL _productDAL;
        private readonly ICategoryDAL _categoryDAL;
        private readonly ISupplierDAL _supplierDAL;

        public ElasticReorganizer(IElasticSearchService elasticSearchService,
            IProductDAL productDAL,
            ICategoryDAL categoryDAL,
            ISupplierDAL supplierDAL)
        {
            _elasticSearchService = elasticSearchService;
            _productDAL = productDAL;
            _categoryDAL = categoryDAL;
            _supplierDAL = supplierDAL;
        }
        [Hangfire.AutomaticRetry(Attempts = 10)]
        public async Task StartReocganizationAsync()
        {
            var products = await (await _productDAL.GetListAsync()).ToListAsync();
            var categories = await (await _categoryDAL.GetListAsync()).ToListAsync();
            var supplieers = await (await _supplierDAL.GetListAsync()).ToListAsync();
            await _elasticSearchService.CreateAllIndexes(products, categories, supplieers);
        }
    }
}
