using ABTS.Entities.Concerete;
using System.Linq;

namespace ABTS.DAL.Abstract
{
    public interface IProductDAL :IBaseDAL<Products>
    {
        IQueryable<Products> GetProductList(string columnName = null, int page = 1, int pageSize = 0, bool isDesc = false);
    }

}
