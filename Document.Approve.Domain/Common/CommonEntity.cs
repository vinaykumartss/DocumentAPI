using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.Domain.Common
{
  public  class CommonEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdateBy { get; set; }

        

    }


}
