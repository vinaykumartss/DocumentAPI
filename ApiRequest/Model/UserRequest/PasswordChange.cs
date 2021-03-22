using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.ApiRequest.Model.UserRequest
{
   public class PasswordChange
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
