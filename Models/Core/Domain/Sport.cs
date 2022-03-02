using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class Sport
    {
        [Key]
        public Guid SportId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //public List<ApplicationUser> InterestedUsers { get; set; }
        public List<Level> Levels { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<Product> Products { get; set; }
    }
}
