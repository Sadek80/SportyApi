using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class UsersInterests
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public Guid SportId { get; set; }
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }
    }
}
