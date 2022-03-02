﻿using Microsoft.AspNetCore.Identity;
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
        public async Task AddUserInterestsAsync(IEnumerable<Guid> SportsGuids, string userId)
        {

            throw new NotImplementedException();

            //var user = await _userManager.FindByIdAsync(userId);

            //if (user is null)
            //    return null;

            //foreach (var sort in SportsGuids)
            //{
            //    var sport = _dataContext.Sports.Where(s => s.SportId == sort);

            //    if (sport is null)
            //        return null;

            //    var usersInterests = new UsersInterests();

            //    usersInterests.UserId = userId;
            //    usersInterests.SportId = sort;

            //    _dataContext.UsersInterests.Add(usersInterests);


             
            //}
        }

        public Task<IEnumerable<Sport>> GetAllSportsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
