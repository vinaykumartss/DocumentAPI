using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.ApiRequest.Model.UserResponse
{
   public class UserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
        public int IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
