using System;
using System.Collections.Generic;

#nullable disable

namespace Ecom.Model
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual TblUser User { get; set; }
    }
}
