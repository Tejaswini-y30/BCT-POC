using System;
using System.Collections.Generic;

#nullable disable

namespace Organic.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
