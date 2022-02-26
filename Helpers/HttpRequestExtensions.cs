using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Helpers
{
    public static class HttpRequestExtensions
    {
        public static string GetRootPath(this HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host}/Images/";
        }
    }
}
