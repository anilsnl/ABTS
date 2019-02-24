using ABTS.DAL.Abstract;
using ABTS.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABTS.DAL.Concerete.EF
{
    public class SupplierDAL : EFBaseDAL<Suppliers>,ISupplierDAL
    {
        private readonly NorthwindContext _context;
        public SupplierDAL(NorthwindContext context) :base(context)
        {
            _context = new NorthwindContext();
        }
    }
}
