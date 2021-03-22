using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Domain.Common
{
  public  class CommonEntity
    {

       
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

    }


}
