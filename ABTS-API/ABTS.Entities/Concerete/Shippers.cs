using ABTS.Entities.Abstract;
using System.Collections.Generic;

namespace ABTS.Entities.Concerete
{
    public partial class Shippers: IEntity
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
