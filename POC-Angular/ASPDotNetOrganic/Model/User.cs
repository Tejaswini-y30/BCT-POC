using System;
using System.Collections.Generic;

#nullable disable

namespace Organic.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
