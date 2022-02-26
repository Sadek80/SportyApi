using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.ResourceParameters
{
    public class BaseResourceParametersForSearchAndFilter
    {
        public string SearchQuery { get; set; }
        public string FilterBy { get; set; }
    }
}
