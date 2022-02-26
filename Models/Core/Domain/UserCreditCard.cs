using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class UserCreditCard : IHasCreditCard
    {
        [Key]
        public Guid CreditCardId { get; set; }
      
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [MaxLength(25)]
        public string CreditCardNumber { get; set; }
        [Required]
        [MaxLength(25)]
        public string ExpirationDate { get; set; }
        [Required]
        [MaxLength(15)]
        public string Zipcode { get; set; }
    }
}
