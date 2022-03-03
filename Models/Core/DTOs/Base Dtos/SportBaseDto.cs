using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class SportBaseDto
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }
    }
}
