using ABTS.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ABTS.Entities.Concrete
{
    public partial class CustomerCustomerDemo : IEntity
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
