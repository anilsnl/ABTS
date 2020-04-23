namespace ABTS.API.Models
{
    public class ProductListModel
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 0;
        public string columnName { get; set; } = null;
        public bool isDesc { get; set; } = false;
    }
}
