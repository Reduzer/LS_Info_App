using Entities.DTOs.GET;
using Entities.Entities;

namespace BackendInfoApp.Mapper {
    public class WeatherDataMapper {
        public GetWeatherDataDTO EntityToGetDTO(WeatherDataEntity oEntity) {
            return new GetWeatherDataDTO (
                oEntity.nId,
                oEntity.sCity,
                oEntity.sCountry,
                oEntity.dTempC,
                oEntity.sConditionText,
                oEntity.dWindKph,
                oEntity.sWindDir,
                oEntity.dFeelsLikeC
            );
        }
    }
}