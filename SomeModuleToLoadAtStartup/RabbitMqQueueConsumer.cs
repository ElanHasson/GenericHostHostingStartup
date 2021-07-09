using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SomeModuleToLoadAtStartup
{
    public class MyInjectedWorker : BackgroundService
    {
        private readonly ILogger<MyInjectedWorker> _logger;

        public MyInjectedWorker(ILogger<MyInjectedWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hello from dynamically loaded {workerType}: {time}", nameof(MyInjectedWorker), DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}