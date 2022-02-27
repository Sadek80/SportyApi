using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserForProfileDto> GetUserProfileAsync(string userId);
        Task UpdateUserProfileAsync(UserForUpdateDto userForUpdate, string userId);
        Task<UserForCartDto> GetUserPaymentDataAsync(string userId);

    }
}
