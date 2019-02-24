using ABTS.Entities.Abstract;

namespace ABTS.Entities.Concerete
{
    public partial class EmployeeTerritories: IEntity
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
