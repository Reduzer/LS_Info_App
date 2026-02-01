using BackendInfoApp.DB;
using BackendInfoApp.Mapper;
using BackendInfoApp.Repositories;
using BackendInfoApp.Services;
using Entities.DTOs.GET;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace BackendInfoApp.Controllers {
    [ApiController]
    [Route("api")]
    public class WeatherDataController : ControllerBase {
        private WeatherDataService oService;

        public WeatherDataController(InfoAppDbContext oContext) {
            oService = new WeatherDataService(oContext);
        }

        [HttpGet]
        public IActionResult GetAllWeatherData() {
            List<GetWeatherDataDTO> voWeatherData = oService.GetAll();
            var oLatestWeatherData = voWeatherData.OrderByDescending(w => w.oRecordedAt).FirstOrDefault();
            string sJsonReturn = JsonConvert.SerializeObject(oLatestWeatherData);
            return Ok(sJsonReturn);
        }

			[HttpGet("Date/{oTime}")]
			public IActionResult GetWeatherData(DateOnly oTime) {
				return BadRequest();
			}
		
			[HttpGet("DateTime/{oTime}")]
			public IActionResult GetWeatherData(DateTime oTime) {
				return BadRequest();
			}
	 }
}
