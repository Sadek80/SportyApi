using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Services
{
    public interface ICreditCardValidationService
    {
        bool IsCreditCardInfoValid(string cardNo, string expiryDate);
        bool IsValidCreditCardNum(string cardNo);
    }
}
