using Document.Approve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Domain.Entities
{
  public class User : CommonEntity
    {
        public int UserId { get; set; }

        public string LogInID { get; set; }

        public string UserDept { get; set; }

        public string UserName { get; set; }

        public string EmaiiId { get; set; }
        public string Password { get; set; }

        public string Password1 { get; set; }

        public string Password2 { get; set; }

        public string Password3 { get; set; }

        public string Password4 { get; set; }

        public string UserStatus { get; set; }

        
    }
}
