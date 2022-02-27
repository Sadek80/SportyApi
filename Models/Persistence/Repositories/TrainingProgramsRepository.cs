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

        public TrainingProgramsRepository(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            throw new NotImplementedException();
        }

        public Task EnrollToTrainingProgramAsync(string userId, Guid programId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync(BaseResourceParametersForSearchAndFilter parameters)
        {
            throw new NotImplementedException();
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
