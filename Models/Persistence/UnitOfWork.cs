using AutoMapper;
using SportyApi.Helpers;
using SportyApi.Models.Core;
using SportyApi.Models.Core.Domain;
using SportyApi.Models.Core.Repositories;
using SportyApi.Models.Persistence.Repositories;
using SportyApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace SportyApi.Models.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _dataContext;
        public IAuthRepository AuthRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public ITrainingProgramsRepository TrainingProgramsRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ISportRepository SportRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }

        public UnitOfWork(AppDataContext dataContext, UserManager<ApplicationUser> userManager,
                                    IOptions<JWT> jwtOptions, IMailService mailService,
                                    IMapper mapper,
                                    ICreditCardValidationService cardValidationService)
        {
            _dataContext = dataContext;

            AuthRepository = new AuthRepository(userManager, jwtOptions, mailService, mapper);
            ProductRepository = new ProductRepository(dataContext);
            TrainingProgramsRepository = new TrainingProgramsRepository(dataContext, userManager);
            UserRepository = new UserRepository(dataContext, userManager, mapper, cardValidationService);
            SportRepository = new SportRepository(dataContext, userManager);
            OrderRepository = new OrderRepository(dataContext, userManager, mapper, cardValidationService);
        }

        public async Task<int> Save()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _dataContext.DisposeAsync();
        }
    }
}
