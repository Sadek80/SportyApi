using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class LinkDto
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }

        public LinkDto(string href, string rel, string method)
        {
            this.href = href;
            this.rel = rel;
            this.method = method;
        }
    }
}
