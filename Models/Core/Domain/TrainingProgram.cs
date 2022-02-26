using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class TrainingProgram
    {
        [Key]
        public Guid TrainingProgramId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string DescriptionMinimized { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Provider { get; set; }
        [Required]
        [MaxLength(450)]
        public string Location { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [Range(1.0, double.MaxValue)]
        public double PricePerMonth{ get; set; }
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }
        public Guid SportId { get; set; }
        [ForeignKey("LevelId")]
        public Level Level { get; set; }
        public Guid LevelId { get; set; }
    }
}
