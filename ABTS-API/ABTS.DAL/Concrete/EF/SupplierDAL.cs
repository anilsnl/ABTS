using ABTS.DAL.Abstract;
using ABTS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTS.DAL.Concrete.EF
{
    public class SupplierDAL : EFBaseDAL<Suppliers>,ISupplierDAL
    {
        private readonly NorthwindContext _context;
        public SupplierDAL(NorthwindContext context) :base(context)
        {
            _context = context;
        }
    }
}
