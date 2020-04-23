using System;
using System.Collections.Generic;
using System.Text;

namespace ABTS.ElasticService.Schema
{
    public class ProductSchema
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
