using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using SportyApi.Models.Core.Repositories;
using SportyApi.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence.Repositories
{
    public class TrainingProgramsRepository : ITrainingProgramsRepository
    {
        private readonly AppDataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrainingProgramsRepository(AppDataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public Task AddTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            throw new NotImplementedException();
        }

        public Task EnrollToTrainingProgramAsync(string userId, Guid programId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync(BaseResourceParametersForSearchAndFilter parameters)
        {
            var trainingPrograms = _dataContext.TrainingPrograms
                .Include(s => s.Sport)
                .ThenInclude(l => l.Levels) as IQueryable<TrainingProgram>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();

                trainingPrograms = trainingPrograms.Where(t => t.Name.Contains(searchQuery) ||
                                               t.Provider.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(parameters.FilterBy))
            {
                var filterBy = parameters.FilterBy.Trim();

                trainingPrograms = trainingPrograms.Where(t => t.Name == filterBy || t.Sport.Name == filterBy);
            }

            return await trainingPrograms.ToListAsync();
        }

        public Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingProgramId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservedProgram>> GeyUserReservedTrainingProgramsAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
