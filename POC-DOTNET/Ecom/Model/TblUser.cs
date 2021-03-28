using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class TblUser
    {
        public TblUser()
        {
            RefreshTokens = new HashSet<RefreshToken>();
            TblCarts = new HashSet<TblCart>();
            TblShippingDetails = new HashSet<TblShippingDetail>();
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblShippingDetail> TblShippingDetails { get; set; }
    }
}
