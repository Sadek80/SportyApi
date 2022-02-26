using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class Level
    {
        [Key]
        public Guid LevelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }
        [MaxLength(50)]
        public Guid SportId { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; }
    }
}
