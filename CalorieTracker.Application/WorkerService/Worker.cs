using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Contracts.Services.Calculators;
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

                var delay = DateTime.Today.AddDays(1) - DateTime.Now;

                await Task.Delay(delay, stoppingToken);

                using var scope = _scopeFactory.CreateScope();

                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var userDataCalculators = scope.ServiceProvider.GetRequiredService<IUserDataCalculators>();

                var userDatas = await unitOfWork.ApplicationUserDataRepository.GetFromWhereAsync();

                foreach (var userData in userDatas)
                {
                    await userDataCalculators.CalculateUserDailyCalorieLimitsAsync(userData);
                }
            }
        }

        //THis is my implementation ->

        /*     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
             {
                 int milisecondsInDay = 86400000;
                 var workerTriggerTimeRemaining = DateTime.Today.AddDays(1) - DateTime.Now;
                 var milisecondsUntilMidnight = Math.Floor(workerTriggerTimeRemaining.TotalMilliseconds);

                 while (!stoppingToken.IsCancellationRequested)
                 {
                     if (_logger.IsEnabled(LogLevel.Information))
                     {
                         _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                     }

                     if (milisecondsUntilMidnight == 0)
                     {
                         using var scope = _scopeFactory.CreateScope();

                         var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                         var userDataCalculators = scope.ServiceProvider.GetRequiredService<IUserDataCalculators>();

                         var userDatas = await unitOfWork.ApplicationUserDataRepository.GetFromWhereAsync();

                         foreach (var userData in userDatas)
                         {
                             await userDataCalculators.CalculateUserDailyCalorieLimitsAsync(userData);
                         }

                         milisecondsUntilMidnight = milisecondsInDay;
                     }


                     await Task.Delay(TimeSpan.FromMilliseconds(milisecondsUntilMidnight), stoppingToken);
                     milisecondsUntilMidnight = 0;
                 }
             }*/
    }
}
