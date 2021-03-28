using System;
using System.Collections.Generic;

namespace Ecom.Model
{
    public  class RefreshRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}