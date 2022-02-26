using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public Address Address { get; set; }
        public List<Sport> SportingInterest { get; set; }
        public List<UserCreditCard> CreditCards { get; set; }
        public List<ReservedProgram> ReservedPrograms { get; set; }
        public List<Order> Orders { get; set; }
    }
}
