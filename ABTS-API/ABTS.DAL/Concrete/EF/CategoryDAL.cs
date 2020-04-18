using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;

namespace ABTS.DAL.Concrete.EF
{
    public class CategoryDAL : EFBaseDAL<Category>,ICategoryDAL
    {
        private readonly NorthwindContext _context;
        public CategoryDAL(NorthwindContext context) :base(context)
        {
            _context = context;
        }
    }
}
