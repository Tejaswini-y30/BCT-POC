using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class TblSeller
    {
        public TblSeller()
        {
            TblCategories = new HashSet<TblCategory>();
            TblProducts = new HashSet<TblProduct>();
        }

        public string SellerId { get; set; }
        public string SellerPassword { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<TblCategory> TblCategories { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
