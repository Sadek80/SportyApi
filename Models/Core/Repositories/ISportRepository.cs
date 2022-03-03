using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface ISportRepository
    {
        Task<IEnumerable<Sport>> GetAllSportsAsync();
        Task<string> AddUserInterestsAsync(IEnumerable<Guid> SportsGuids, string userId);
    }
}
