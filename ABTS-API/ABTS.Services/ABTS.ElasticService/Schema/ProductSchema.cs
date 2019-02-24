using System;
using System.Collections.Generic;
using System.Text;

namespace ABTS.ElasticService.Schema
{
    public class ProductSchema
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
    }
}
