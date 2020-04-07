using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;

namespace ABTS.DAL.Concrete.EF
{
    public class CategoryDAL : EFBaseDAL<Categories>,ICategoryDAL
    {
        private readonly NorthwindContext _context;
        public CategoryDAL(NorthwindContext context) :base(context)
        {
            _context = context;
        }
    }
}
