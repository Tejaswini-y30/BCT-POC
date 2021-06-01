using System;
using System.Collections.Generic;

#nullable disable

namespace Organic.Model
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? UserId { get; set; }
    }
}
