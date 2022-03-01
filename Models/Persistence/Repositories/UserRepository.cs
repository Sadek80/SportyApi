using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.Models.Core.Repositories;
using SportyApi.Services;
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
        private readonly ICreditCardValidationService _cardValidationService;

        public UserRepository(AppDataContext dataContext, UserManager<ApplicationUser> userManager,
                                                          IMapper mapper,
                                                          ICreditCardValidationService cardValidationService)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapper = mapper;
            _cardValidationService = cardValidationService;
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
                        if (!_cardValidationService.IsCreditCardInfoValid(card.CreditCardNumber, card.ExpirationDate))
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

    }
}
