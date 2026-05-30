using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Services.Calculations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Worker_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                using var scope = _scopeFactory.CreateScope();

                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var userDatas = await unitOfWork.ApplicationUserDataRepository.GetFromWhereAsync();

                foreach (var userData in userDatas)
                {

                    var calculators = new UserDataCalculators(unitOfWork, userData.Id);
                    await calculators.CalculateUserDailyCalorieLimitsAsync(userData);
                    await unitOfWork.CommitAsync();
                }
                await Task.Delay(80000000, stoppingToken);
            }
        }
    }
}
