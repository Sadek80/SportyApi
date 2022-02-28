using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.UserDtos;
using SportyApi.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (user.CreditCards is not null)
                userForCartDto.CreditCards = _mapper.Map<List<CreditCardDto>>(user.CreditCards);

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

            if(user.CreditCards is not null)
                userForProfile.CreditCards = _mapper.Map<List<CreditCardDto>>(user.CreditCards);

            return userForProfile;
        }

        public Task UpdateUserProfileAsync(UserForUpdateDto userForUpdate, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
