using BackendInfoApp.Controllers;
using BackendInfoApp.DB;

namespace BackendInfoApp.Services {
    public class WeatherUpdateService : BackgroundService {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WeatherUpdateService> _logger;

        public WeatherUpdateService(IServiceProvider serviceProvider, ILogger<WeatherUpdateService> logger) {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("WeatherUpdateService gestartet");

            // Beim Start sofort ausführen
            await UpdateWeatherData(stoppingToken);

            // Dann stündlich wiederholen
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(20));
            
            try {
                while (await timer.WaitForNextTickAsync(stoppingToken)) {
                    await UpdateWeatherData(stoppingToken);
                }
            } catch (OperationCanceledException) {
                _logger.LogInformation("WeatherUpdateService wurde beendet");
            }
        }

        private async Task UpdateWeatherData(CancellationToken stoppingToken) {
            try {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<InfoAppDbContext>();
                var controller = new WeatherDataController(dbContext);

                var result = controller.GetWeatherFromApi();
                if (result != null) {
                    _logger.LogInformation($"Wetterdaten aktualisiert: {result.sCity}");
                } else {
                    _logger.LogWarning("Wetterdaten konnten nicht aktualisiert werden");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Fehler beim Aktualisieren der Wetterdaten");
            }

            await Task.CompletedTask;
        }
    }
}