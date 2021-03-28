using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class TblCart
    {
        public decimal QuantityWished { get; set; }
        public DateTime DateAdded { get; set; }
        public string CartId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string Purchased { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblUser User { get; set; }
    }
}
