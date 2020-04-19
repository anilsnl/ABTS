using ABTS.Core.DAL.Abstract;

namespace ABTS.Entities.Concrete
{
    public partial class EmployeeTerritorie : IEntity
    {
        public short EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
