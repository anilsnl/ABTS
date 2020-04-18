using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ABTS.DAL.Concrete.EF
{
    public class ProductDAL : EFBaseDAL<Product>,IProductDAL
    {
        private readonly NorthwindContext _context;
        public ProductDAL(NorthwindContext context) : base(context)
        {
            _context = context;
        }
        
        public IQueryable<Product> GetProductList(string columnName=null,int page = 1, int pageSize = 0,bool isDesc=false)
        {
            pageSize = pageSize < 1 ? _context.Products.Count() : pageSize;
            page = page < 1 ? 1 : page;
            var query = new StringBuilder("SELECT * FROM Products p ORDER BY ");
            if (string.IsNullOrEmpty(columnName))
            {
                columnName = "ProductId";
            }
            query.Append(columnName);
            string strSortType = isDesc ? "desc" : "asc";
            query.Append($" {strSortType} OFFSET ({pageSize*(page-1)}) ROWS FETCH NEXT ({pageSize}) ROWS ONLY");
            return  _context.Products.FromSqlRaw(query.ToString());
        }

    }
}
