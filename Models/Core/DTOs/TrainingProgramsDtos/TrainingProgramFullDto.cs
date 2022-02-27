using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.TrainingProgramsDtos
{
    public class TrainingProgramFullDto : TrainingProgramBaseDto
    {
        public Guid TrainingProgramId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Provider { get; set; }
        public string Location { get; set; }
        public double PricePerMonth { get; set; }
        public string SportName { get; set; }

    }
}
