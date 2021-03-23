using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.ApiRequest.Model.UserResponse
{
   public class UserResponse
    {
        public int UserId { get; set; }

        public string LogInID { get; set; }

        public string UserDept { get; set; }

        public string UserName { get; set; }

        public string EmaiiId { get; set; }
     
        public string UserStatus { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

    }
   

    }
