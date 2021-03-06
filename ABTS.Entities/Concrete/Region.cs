﻿using ABTS.Core.DAL.Abstract;
using System.Collections.Generic;

namespace ABTS.Entities.Concrete
{
    public partial class Region : IEntity
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public short RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
