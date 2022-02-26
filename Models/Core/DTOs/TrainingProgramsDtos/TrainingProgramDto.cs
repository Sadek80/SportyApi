using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.TrainingProgramsDtos
{
    public class TrainingProgramDto : TrainingProgramBaseDto
    {
        public Guid TrainingProgramId { get; set; }
        public string ImageUrl { get; set; }
        public string DescriptionMinimized { get; set; }
    }
}
