using Document.Approve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Domain.Entities
{
  public class Department 
    {

        public int Id { get; set; }

        public string DepId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
