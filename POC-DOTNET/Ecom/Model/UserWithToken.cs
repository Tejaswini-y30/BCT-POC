  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Model;

namespace Ecom.Model
{
    public class UserWithToken : TblUser
    {
        
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(TblUser user)
        {
            this.UserId = user.UserId;
            this.UserPassword  = user.UserPassword ; 
            this.Email   =user.Email;        
            this.Firstname = user.Firstname;
            this.Lastname = user.Lastname;
            this.Active = user.Active;
        }
    }
}