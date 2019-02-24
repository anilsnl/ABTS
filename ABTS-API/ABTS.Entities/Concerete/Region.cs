using ABTS.Entities.Abstract;
using System.Collections.Generic;

namespace ABTS.Entities.Concerete
{
    public partial class Region: IEntity
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
