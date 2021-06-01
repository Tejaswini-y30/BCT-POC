using System;
using System.Collections.Generic;

#nullable disable

namespace Organic.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Date { get; set; }
    }
}
