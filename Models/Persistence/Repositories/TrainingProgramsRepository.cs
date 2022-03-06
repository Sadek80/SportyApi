using AutoMapper;
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
        private readonly IMapper _mapper;

        public TrainingProgramsRepository(AppDataContext dataContext,
            UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapper = mapper;
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

            var trainingrogram = _dataContext.TrainingPrograms.FirstOrDefault(t => t.TrainingProgramId == programId);

            if (trainingrogram is null)
                return "Invalid program!";

            var alreadyReserved = _dataContext.ReservedPrograms.Where(r => r.UserId == userId)
                                                               .FirstOrDefault(ur => ur.TrainingProgramId == programId);

            if (alreadyReserved is not null)
                return "Already Enrolled!";

            var reservedProgram = new ReservedProgram
            {
                UserId = userId,
                TrainingProgramId = programId,
                Date = DateTimeOffset.UtcNow
            };

            _dataContext.ReservedPrograms.Add(reservedProgram);

            return "You have successfully enrolled.";
        }

        public async Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync
            (BaseResourceParametersForSearchAndFilter parameters, string userId)
        {
            var userInterests = await _dataContext.UsersInterests
                                                               .Where(ui => ui.UserId == userId)
                                                               .Select(u => u.SportId).ToListAsync();
            var trainingPrograms = _dataContext.TrainingPrograms
                .Include(s => s.Sport)
                .ThenInclude(l => l.Levels) as IQueryable<TrainingProgram>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();

                trainingPrograms = trainingPrograms.Where(t => t.Name.Contains(searchQuery) ||
                                               t.Provider.Contains(searchQuery)
                                               || t.Sport.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(parameters.FilterBy))
            {
                var filterBy = parameters.FilterBy.Trim();

                trainingPrograms = trainingPrograms.Where(t => t.Sport.Name == filterBy);
            }

            List<TrainingProgram> programsList;
            programsList = await trainingPrograms.ToListAsync();


            if (userInterests.Count != 0)
                programsList = programsList.OrderByDescending(p => userInterests.IndexOf(p.SportId)).ToList();

            return await trainingPrograms.ToListAsync();
        }

        public async Task<TrainingProgramFullDto> GetTrainingProgramByIdAsync(Guid trainingProgramId, string userId)
        {

            var trainingProgram = await _dataContext.TrainingPrograms
                .Include(t => t.Sport)
                .ThenInclude(tl => tl.Levels)
                .FirstOrDefaultAsync(t => t.TrainingProgramId == trainingProgramId);

            var programFullDto = _mapper.Map<TrainingProgramFullDto>(trainingProgram);

            var alreadyReserved = await _dataContext.ReservedPrograms.Where(r => r.UserId == userId)
               .FirstOrDefaultAsync(ur => ur.TrainingProgramId == trainingProgramId);

            if (alreadyReserved is not null)
                programFullDto.IsReserved = true;

            return programFullDto;
        }

        public async Task<IEnumerable<ReservedProgram>> GeyUserReservedTrainingProgramsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return null;

            var programs = await _dataContext.ReservedPrograms.Where(t => t.UserId == userId).ToListAsync();

            foreach (var program in programs)
            {
                program.TrainingProgram = (TrainingProgram)_dataContext.TrainingPrograms
                    .Where(t => t.TrainingProgramId == program.TrainingProgramId)
                    .Include(ts => ts.Sport)
                    .ThenInclude(tl => tl.Levels)
                    .SingleOrDefault();
            }

            return programs;
        }
    }
}
