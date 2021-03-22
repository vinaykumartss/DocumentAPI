using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.ApiRequest.Model.Department.DepartmentRequest
{
    public class DepartmentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
