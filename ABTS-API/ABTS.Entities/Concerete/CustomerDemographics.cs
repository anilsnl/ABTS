﻿using ABTS.Entities.Abstract;
using System.Collections.Generic;

namespace ABTS.Entities.Concerete
{
    public partial class CustomerDemographics:IEntity
    {
        public CustomerDemographics()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}
