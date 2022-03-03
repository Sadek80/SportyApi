using Microsoft.AspNetCore.Identity;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class SportRepository : ISportRepository
    {
        private readonly AppDataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public SportRepository(AppDataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }
        public async Task<string> AddUserInterestsAsync(IEnumerable<Guid> SportsGuids, string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return "Invalid User!";

            foreach (var sport in SportsGuids)
            {
                var sports = _dataContext.Sports.FirstOrDefault(s => s.SportId == sport);

                if (sports is null)
                    return "Invalid Sport!";

                var usersInterests = new UsersInterests
                {
                    UserId = userId,
                    SportId = sport
                };

                _dataContext.UsersInterests.Add(usersInterests);
            }
            return "Interests added successfully.";
        }

        public Task<IEnumerable<Sport>> GetAllSportsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
