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
        private WeatherDataRepository oRepository;
        private WeatherDataMapper oMapper;

        public WeatherDataController(InfoAppDbContext oContext) {
            oService = new WeatherDataService(oContext);
            oRepository = new WeatherDataRepository(oContext);
            oMapper = new WeatherDataMapper();
        }

        [HttpGet("GetRecentWeatherData")]
        public IActionResult GetAllWeatherData() {
            List<GetWeatherDataDTO> voWeatherData = oService.GetAll();
            var oLatestWeatherData = voWeatherData.OrderByDescending(w => w.oRecordedAt).FirstOrDefault();
            string sJsonReturn = JsonConvert.SerializeObject(oLatestWeatherData);
            return Ok(sJsonReturn);
        }

        public WeatherDataEntity? GetWeatherFromApi() {
            string sJSON = System.IO.File.ReadAllText("config.json");
            JObject oConfig = JObject.Parse(sJSON);
            string sCity = oConfig["WeatherApi"]["City"].ToString();
            string sApiKey = oConfig["WeatherApi"]["ApiKey"].ToString();

            if (string.IsNullOrWhiteSpace(sCity))
                throw new ArgumentException("sCity must be provided", nameof(sCity));

            if (string.IsNullOrWhiteSpace(sApiKey))
                throw new ArgumentException("sApiKey must be provided", nameof(sApiKey));

            // Build request URL according to weatherapi.com current endpoint
            string sUrl = $"{oConfig["WeatherApi"]["BaseUrl"]}{Uri.EscapeDataString(sApiKey)}&q={Uri.EscapeDataString(sCity)}&aqi=no";

            try {
                using var oClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var oResponse = oClient.GetAsync(sUrl).GetAwaiter().GetResult();

                if (!oResponse.IsSuccessStatusCode) {
                    // simple handling: return null on upstream error
                    return null;
                }

                string sJson = oResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                using var oDoc = JsonDocument.Parse(sJson);
                var oRoot = oDoc.RootElement;

                if (!oRoot.TryGetProperty("location", out var oLocation) || !oRoot.TryGetProperty("current", out var oCurrent))
                    return null;

                string sResolvedCity = oLocation.GetProperty("name").GetString() ?? sCity;
                string sCountry = oLocation.GetProperty("country").GetString() ?? string.Empty;

                // current fields (use GetDouble / GetString; this will throw if missing / wrong type)
                double dTempC = oCurrent.GetProperty("temp_c").GetDouble();
                string sCondition = oCurrent.GetProperty("condition").GetProperty("text").GetString() ?? string.Empty;
                double dWindKph = oCurrent.GetProperty("wind_kph").GetDouble();
                string sWindDir = oCurrent.GetProperty("wind_dir").GetString() ?? string.Empty;
                double dFeelsLikeC = oCurrent.GetProperty("feelslike_c").GetDouble();

                // Create entity (nId = 0 for new insert)
                var oEntity = new WeatherDataEntity(0, sResolvedCity, sCountry, dTempC, sCondition, dWindKph, sWindDir, dFeelsLikeC);

                // Persist through repository (keeps current sync style of project)
                int nNewId = oRepository.PostWeatherDataService(oEntity);
                oEntity.nId = nNewId;

                return oEntity;
            } catch (Newtonsoft.Json.JsonException) {
                // upstream returned unexpected JSON
                return null;
            } catch (HttpRequestException) {
                // network issue
                return null;
            } catch (Exception) {
                // fallback: do not bubble internal exceptions here in this simple helper
                return null;
            }
        }
    }
}
