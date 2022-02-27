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
        Task<IEnumerable<TrainingProgram>> GetAllTrainingPrograms(BaseResourceParametersForSearchAndFilter parameters);
        Task<TrainingProgram> GetTrainingProgramById(Guid trainingProgramId);
        Task<IEnumerable<ReservedProgram>> GeyUserReservedTrainingPrograms(string userId);
        Task<bool> AddTrainingProgram(TrainingProgram trainingProgram);
        Task<bool> EnrollToTrainingProgram(string userId, Guid programId);
    }
}
