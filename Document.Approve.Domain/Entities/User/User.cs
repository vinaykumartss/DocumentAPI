using Document.Approve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Domain.Entities
{
  public class User : CommonEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }

        public int IsActive { get; set; }
    }
}
