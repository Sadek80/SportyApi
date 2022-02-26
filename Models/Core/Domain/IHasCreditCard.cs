using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Domain
{
    public interface IHasCreditCard
    {
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Zipcode { get; set; }
    }
}
