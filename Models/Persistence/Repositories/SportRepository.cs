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
        public Task AddUserInterestsAsync(IEnumerable<Guid> SportsGuids, string userId)
        {

            throw new NotImplementedException();
            //foreach (var sort in SportsGuids)
            //{
            //    var sport = _dataContext.Sports.Where(s => s.SportId == sort);

            //    if (sport is null)
            //        return null;

            //    var sport = new Sport();

            //    sport.

            //    _dataContext.Sports.Add()
            //}
        }

        public Task<IEnumerable<Sport>> GetAllSportsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
