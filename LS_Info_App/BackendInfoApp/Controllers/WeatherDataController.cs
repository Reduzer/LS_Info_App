using BackendInfoApp.DB;
using BackendInfoApp.Services;
using Entities.DTOs.GET;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendInfoApp.Controllers {
    [ApiController]
    [Route("api")]
    public class WeatherDataController : ControllerBase {
        private WeatherDataService oService;

        public WeatherDataController(InfoAppDbContext oContext) {
            oService = new WeatherDataService(oContext);
        }

        [HttpGet("GetRecentWeatherData")]
        public IActionResult GetAllWeatherData() {
            GetWeatherDataDTO oWeatherData = oService.GetLatest();
            string sJsonReturn = JsonConvert.SerializeObject(oWeatherData);
            return Ok(sJsonReturn);
        }
    }
}
