using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportyApi.Services
{
    public class CreditCardValidationService : ICreditCardValidationService
    {
        public bool IsCreditCardInfoValid(string cardNo, string expiryDate)
        {
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");

            if (!IsValidCreditCardNum(cardNo))
                return false;


            var dateParts = expiryDate.Split('/');
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1]))
                return false;

            var year = int.Parse(dateParts[1]);
            var month = int.Parse(dateParts[0]);

            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month);
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }

        public bool IsValidCreditCardNum(string cardNo)
        {
            if (cardNo.Length < 15)
                return false;

            int[] cardInt = new int[cardNo.Length];
            int sum = 0;

            for (int i = 0; i < cardInt.Length; i++)
            {
                cardInt[i] = (int)(cardNo[i] - '0');
            }

            for (int i = cardInt.Length - 2; i >= 0; i -= 2)
            {
                int temp = cardInt[i];
                temp *= 2;

                if (temp > 9)
                    temp = temp % 10 + 1;

                cardInt[i] = temp;
                sum += temp + cardInt[i + 1];
            }

            return sum % 10 == 0;
        }
    }
}
