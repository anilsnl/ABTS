using ABTS.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ABTS.Entities.Concrete
{
    public partial class Shipper : IEntity
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public short ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
