using SportyApi.Models.Core.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserForProfileDto> GetUserProfile(string userId);
        Task<bool> UpdateUserProfile(UserForUpdateDto userForUpdate, string userId);
        Task<UserForCartDto> GetUserPaymentData(string userId);

    }
}
