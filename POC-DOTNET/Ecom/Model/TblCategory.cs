using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public string CategoryId { get; set; }
        public string CatergoryName { get; set; }
        public string SellerId { get; set; }

        public virtual TblSeller Seller { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
