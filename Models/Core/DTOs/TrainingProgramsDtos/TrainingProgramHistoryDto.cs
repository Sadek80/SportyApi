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
        public DateTimeOffset Date { get; set; }
    }
}
