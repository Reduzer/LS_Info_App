using Entities.DTOs.GET;

namespace FrontendInfoApp.APIConnection.Interfaces {
    internal interface IGet {
        public GetWeatherDataDTO WeatherData();

        //public GetWeatherDataDTO GetWeatherDataDTO(long nID);
    }
}
