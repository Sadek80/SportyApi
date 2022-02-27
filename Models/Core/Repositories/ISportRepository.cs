using SportyApi.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface ISportRepository
    {
        Task<IEnumerable<Sport>> GetAllSprtsAsync();
        Task AddUserInterestsAsync(IEnumerable<Guid> SportsGuids);
    }
}
