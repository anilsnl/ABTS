using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;

namespace ABTS.DAL.Concrete.EF
{
    public class SupplierDAL : EFBaseDAL<Supplier>, ISupplierDAL
    {
        private readonly NorthwindContext _context;
        public SupplierDAL(NorthwindContext context) : base(context)
        {
            _context = context;
        }
    }
}
