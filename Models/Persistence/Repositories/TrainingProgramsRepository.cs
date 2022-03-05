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

        public async Task<string> EnrollToTrainingProgramAsync(string userId, Guid programId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return "Invalid User!";

            var trainingrogram = _dataContext.ReservedPrograms.Where(t => t.TrainingProgramId == programId);

            if (trainingrogram is null)
                return "Invalid program!";

            var reservedProgram = new ReservedProgram
            {
                UserId = userId,
                TrainingProgramId = programId,
                Date = DateTime.Now
            };

            _dataContext.ReservedPrograms.Add(reservedProgram);

            return "You have successfully enrolled.";
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

        public async Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingProgramId)
        {
            if (trainingProgramId == Guid.Empty)
                throw new ArgumentNullException(nameof(trainingProgramId));

            return await _dataContext.TrainingPrograms
                .Include(t => t.Sport)
                .ThenInclude(tl => tl.Levels)
                .FirstOrDefaultAsync(t => t.TrainingProgramId == trainingProgramId);
        }

        public async Task<IEnumerable<ReservedProgram>> GeyUserReservedTrainingProgramsAsync(string userId)
        {
            //var user = await _userManager.FindByIdAsync(userId);

            //if (user is null)
            //    return null;

            //var programs = await _dataContext.ReservedPrograms.Where(t => t.UserId == userId).ToListAsync();

            //foreach (var program in programs)
            //{
            //    program.TrainingProgram = (TrainingProgram)_dataContext.TrainingPrograms
            //        .Where(t => t.TrainingProgramId == program.TrainingProgramId)
            //        .Include(ts => ts.Sport)
            //        .ThenInclude(tl => tl.Levels);
            //}

            //return programs; 
            throw new NotImplementedException();
        }
    }
}
