using ABTS.Core.DAL.Abstract;
using System.Collections.Generic;

namespace ABTS.Entities.Concrete
{
    public partial class Territory : IEntity
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritorie>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public short RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritorie> EmployeeTerritories { get; set; }
    }
}
