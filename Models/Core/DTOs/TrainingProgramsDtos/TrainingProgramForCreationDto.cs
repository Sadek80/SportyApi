using SportyApi.Models.Core.DTOs.Base_Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.TrainingProgramsDtos
{
    public class TrainingProgramForCreationDto : TrainingProgramBaseDto
    {
        [Required]
        public override string Name { get => base.Name; set => base.Name = value; }
        [Required]
        public override string SportName { get => base.SportName; set => base.SportName = value; }
        [Required]
        public override string Level { get => base.Level; set => base.Level = value; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1.0, double.MaxValue)]
        public double PricePerMonth{ get; set; }
        [Required]
        public string DescriptionMinimized { get; set; }

    }
}
