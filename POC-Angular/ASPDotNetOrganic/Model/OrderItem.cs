using System;
using System.Collections.Generic;

#nullable disable

namespace Organic.Model
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal? Price { get; set; }
    }
}
