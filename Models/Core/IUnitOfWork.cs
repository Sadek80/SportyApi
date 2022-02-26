using SportyApi.Models.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace SportyApi.Models.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        ITrainingProgramsRepository TrainingProgramsRepository{ get; set; }
        IUserRepository UserRepository{ get; set; }
        ISportRepository SportRepository{ get; set; }
        IOrderRepository OrderRepository{ get; set; }

        Task<int> Save();
    }
}
