using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class TblShippingDetail
    {
        public string ShippingDetailId { get; set; }
        public string UserId { get; set; }
        public string Uaddress { get; set; }
        public string Ucity { get; set; }
        public string Ustate { get; set; }
        public string Ucountry { get; set; }
        public string UzipCode { get; set; }
        public string ProductId { get; set; }
        public decimal? AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblUser User { get; set; }
    }
}
