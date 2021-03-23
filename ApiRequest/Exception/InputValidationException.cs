
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Document.Approve.ApiRequest.Exceptions
{
    public class InputValidationException : Exception
    {
        public InputValidationException(string message) : base(message) { }
    }
    public class SAPException : HttpRequestException
    {
        public SAPException(string message) : base(message) { }
    }
}
