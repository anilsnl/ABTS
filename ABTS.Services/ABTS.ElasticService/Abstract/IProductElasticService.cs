using ABTS.ElasticService.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABTS.ElasticService.Abstract
{
    public interface IProductElasticService
    {
        Task<IEnumerable<ProductSchema>> GetProductsByName(string keyword);

    }
}
