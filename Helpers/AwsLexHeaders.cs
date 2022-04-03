using System;
using System.Collections.Generic;
using System.Text;

namespace SportyApi.Helpers
{
    public class AwsLexHeaders
    {
        public string AuthorizationHeader { get; set; }
        public string XAmzDate { get; set; }
        public string Host { get; set; }
        public string XAmzContentSha256 { get; set; }
    }
}
