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

        public UserRepository(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<UserForCartDto> GetUserPaymentData(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserForProfileDto> GetUserProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfile(UserForUpdateDto userForUpdate, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
