using Entities.DTOs.GET;
using Entities.DTOs.POST;
using Entities.DTOs.PUT;
using Entities.Entities;

namespace BackendInfoApp.Mapper {
    public class WeatherDataMapper {

        public WeatherDataEntity PostDTOToEntity(PostWeatherDataDTO oDTO) {
            return new WeatherDataEntity {
                sCity = oDTO.sCity,
                sCountry = oDTO.sCountry,
                dTempC = oDTO.dTempC,
                sConditionText = oDTO.sConditionText,
                dWindKph = oDTO.dWindKph,
                sWindDir = oDTO.sWindDir,
                dFeelsLikeC = oDTO.dFeelsLikeC
            };
        }

        public WeatherDataEntity PutDTOToEntity(PutWeatherDataDTO oDTO) {
            return new WeatherDataEntity {
                sCity = oDTO.sCity,
                sCountry = oDTO.sCountry,
                dTempC = oDTO.dTempC,
                sConditionText = oDTO.sConditionText,
                dWindKph = oDTO.dWindKph,
                sWindDir = oDTO.sWindDir,
                dFeelsLikeC = oDTO.dFeelsLikeC
            };
        }

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