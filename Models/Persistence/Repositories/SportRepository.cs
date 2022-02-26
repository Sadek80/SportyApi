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

        public SportRepository(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Task<bool> AddUserInterests(IEnumerable<Guid> SportsGuids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sport>> GetAllSprts()
        {
            throw new NotImplementedException();
        }
    }
}
