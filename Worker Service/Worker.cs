using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Application.Services.Calculations;
using Serilog;

namespace Worker_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public Worker(ILogger<Worker> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                var userDatas = await _unitOfWork.ApplicationUserDataRepository.GetFromWhereAsync();
                var calculators = new UserDataCalculators(_unitOfWork);

                foreach(var userData in userDatas)
                {
                    await calculators.CalculateUserDailyCalorieLimitsAsync(userData);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
