using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using SportyApi.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.Repositories
{
    public interface ITrainingProgramsRepository
    {
        Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync(BaseResourceParametersForSearchAndFilter parameters);
        Task<TrainingProgramFullDto> GetTrainingProgramByIdAsync(Guid trainingProgramId, string userId);
        Task<IEnumerable<ReservedProgram>> GeyUserReservedTrainingProgramsAsync(string userId);
        Task AddTrainingProgramAsync(TrainingProgram trainingProgram);
        Task<string> EnrollToTrainingProgramAsync(string userId, Guid programId);
    }
}
