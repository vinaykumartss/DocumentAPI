using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Approve.ApiRequest.Model
{
   public class ApiResponse
    { 
        public bool IsSuccess { get; set; }

        public string ErrorMessage  { get; set; }

        public object Response { get; set; }

    }
}
