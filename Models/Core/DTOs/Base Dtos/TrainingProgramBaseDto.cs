using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.Base_Dtos
{
    public class TrainingProgramBaseDto
    {
        public virtual string Name { get; set; }
        //public virtual string ImageUrl { get; set; }
        public virtual string Level { get; set; }
    }
}
