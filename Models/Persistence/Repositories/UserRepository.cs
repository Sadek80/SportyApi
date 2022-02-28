using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(AppDataContext dataContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserForCartDto> GetUserPaymentDataAsync(string userId)
        {
            var userForCartDto = new UserForCartDto();

            var user = await _userManager.FindByIdAsync(userId);

            if(user is null)
            {
                userForCartDto.Success = false;
                userForCartDto.Message = "Invalid User";
                userForCartDto.StatusCode = StatusCodes.Status400BadRequest;
                return userForCartDto;
            }

            userForCartDto.Address = user.Address;

            var creditCards = await _dataContext.CreditCards.Where(c => c.UserId == user.Id).ToListAsync();

            if (creditCards is not null)
                userForCartDto.CreditCards = _mapper.Map<List<CreditCardDto>>(creditCards);

            userForCartDto.Success = true;

            return userForCartDto;
        }

        public async Task<UserForProfileDto> GetUserProfileAsync(string userId)
        {
            var userForProfile = new UserForProfileDto();

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                userForProfile.Success = false;
                userForProfile.Message = "Invalid User";
                userForProfile.StatusCode = StatusCodes.Status400BadRequest;
                return userForProfile;
            }

            userForProfile = _mapper.Map<UserForProfileDto>(user);
            userForProfile.Success = true;

            var creditCards = await _dataContext.CreditCards.Where(c => c.UserId == user.Id).ToListAsync();

            if(creditCards is not null)
                userForProfile.CreditCards = _mapper.Map<List<CreditCardDto>>(creditCards);

            return userForProfile;
        }

        public async Task<UserForProfileDto> UpdateUserProfileAsync(UserForUpdateDto userForUpdate, string userId)
        {
            var userForProfile = new UserForProfileDto();

            var user = await _userManager.FindByIdAsync(userId);

            if(user is null)
            {
                userForProfile.Success = false;
                userForProfile.Message = "Invalid User";
                userForProfile.StatusCode = StatusCodes.Status400BadRequest;
                return userForProfile;
            }

            user.FirstName = userForUpdate.FirstName;
            user.LastName = userForUpdate.LastName;
            user.Email = userForUpdate.Email;

            if(userForUpdate.Address is not null)
                user.Address = userForUpdate.Address;

            if (userForUpdate.CreditCard is not null)
            {
                if (userForUpdate.CreditCard.Count > 0)
                {
                    foreach (var card in userForUpdate.CreditCard)
                    {
                        if (!IsCreditCardInfoValid(card.CreditCardNumber, card.ExpirationDate))
                        {
                            userForProfile.Success = false;
                            userForProfile.Message = "Error Happened While Updating, Try Again Later.";
                            userForProfile.StatusCode = StatusCodes.Status422UnprocessableEntity;
                            return userForProfile;
                        }

                        if(card.CreditCardId == Guid.Empty)
                        {
                            var creditCard = _mapper.Map<UserCreditCard>(card);
                            creditCard.CreditCardId = Guid.NewGuid();
                            creditCard.UserId = user.Id;

                            var userCreditCard = await _dataContext.CreditCards
                                                                .FirstOrDefaultAsync(c => c.UserId == user.Id
                                                                          && c.CreditCardNumber == card.CreditCardNumber);

                            if(userCreditCard is not null)
                            {
                                userForProfile.Success = false;
                                userForProfile.Message = "Error Happened While Updating, you can't use the same card.";
                                userForProfile.StatusCode = StatusCodes.Status422UnprocessableEntity;
                                return userForProfile;
                            }

                            _dataContext.CreditCards.Add(creditCard);
                            card.CreditCardId = creditCard.CreditCardId;
                        }
                        else
                        {
                            var userCreditCard = await _dataContext.CreditCards
                                                                .FirstOrDefaultAsync(c => c.UserId == user.Id
                                                                                && c.CreditCardId == card.CreditCardId);

                            userCreditCard.CreditCardNumber = card.CreditCardNumber;
                            userCreditCard.ExpirationDate = card.ExpirationDate;
                            userCreditCard.Zipcode = card.Zipcode;

                            _dataContext.CreditCards.Update(userCreditCard);
                        }
                    }
                }
            }
            
           var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                userForProfile.Success = false;
                userForProfile.Message = "Error Happened While Updating, Try Again Later.";
                userForProfile.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return userForProfile;
            }

            userForProfile = _mapper.Map<UserForProfileDto>(user);
            userForProfile.Success = true;

            if (userForUpdate.CreditCard is not null)
                userForProfile.CreditCards = _mapper.Map<List<CreditCardDto>>(userForUpdate.CreditCard);
            else
            {
                var userCreditCards = _dataContext.CreditCards.Where(c => c.UserId == user.Id);
                userForProfile.CreditCards = _mapper.Map<List<CreditCardDto>>(userCreditCards);
            }

            return userForProfile;
        }

        private bool IsCreditCardInfoValid(string cardNo, string expiryDate)
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

        private bool IsValidCreditCardNum(string cardNo)
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
