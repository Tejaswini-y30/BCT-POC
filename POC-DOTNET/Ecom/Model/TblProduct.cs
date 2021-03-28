using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
#nullable disable

namespace Ecom.Model
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblCarts = new HashSet<TblCart>();
            TblShippingDetails = new HashSet<TblShippingDetail>();
        }

        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public decimal Cost { get; set; }
        public decimal Quantity { get; set; }
        public string SellerId { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductImage { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual TblSeller Seller { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblShippingDetail> TblShippingDetails { get; set; }
    }



}
