using ABTS.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ABTS.Entities.Concrete
{
    public partial class UsState : IEntity
    {
        public short StateId { get; set; }
        public string StateName { get; set; }
        public string StateAbbr { get; set; }
        public string StateRegion { get; set; }
    }
}
