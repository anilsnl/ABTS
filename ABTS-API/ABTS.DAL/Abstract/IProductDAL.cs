using ABTS.Entities.Concrete;
using System.Linq;

namespace ABTS.DAL.Abstract
{
    public interface IProductDAL :IBaseDAL<Product>
    {
        IQueryable<Product> GetProductList(string columnName = null, int page = 1, int pageSize = 0, bool isDesc = false);
    }

}
