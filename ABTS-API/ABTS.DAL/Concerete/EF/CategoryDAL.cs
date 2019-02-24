using ABTS.DAL.Abstract;
using ABTS.Entities.Concerete;

namespace ABTS.DAL.Concerete.EF
{
    public class CategoryDAL : EFBaseDAL<Categories>,ICategoryDAL
    {
        private readonly NorthwindContext _context;
        public CategoryDAL(NorthwindContext context) :base(context)
        {
            _context = new NorthwindContext();
        }
    }
}
