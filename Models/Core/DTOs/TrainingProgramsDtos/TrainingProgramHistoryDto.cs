using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.TrainingProgramsDtos
{
    public class TrainingProgramHistoryDto : TrainingProgramBaseDto
    {
        public string DescriptionMinimized { get; set; }
        public string Date { get; set; }
        public string SportName { get; set; }
        public double PricePerMonth { get; set; }
        public virtual string ImageUrl { get; set; }
    }
}
