using BackendInfoApp.DB;
using BackendInfoApp.Mapper;
using BackendInfoApp.Repositories;
using Entities.DTOs.GET;
using Entities.DTOs.POST;
using Entities.DTOs.PUT;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackendInfoApp.Services {
    public class WeatherDataService {
        private WeatherDataRepository oRepository;
        private WeatherDataMapper oMapper;

        public WeatherDataService(InfoAppDbContext oContext) {
            oRepository = new WeatherDataRepository(oContext);
            oMapper = new WeatherDataMapper();
        }

        public bool Post(PostWeatherDataDTO oDTO) {
            WeatherDataEntity oEntity = oMapper.PostDTOToEntity(oDTO);
            int nID = oRepository.PostWeatherDataService(oEntity);
            if (nID < 1) {
                return true;
            } else {
                return false;
            }
        }

        public WeatherDataEntity Put(PutWeatherDataDTO oDTO) {
            WeatherDataEntity oEntity = oMapper.PutDTOToEntity(oDTO);
            oRepository.PutWeatherDataService(oEntity);

            return oRepository.GetByID(oEntity.nId);
        }

        public List<GetWeatherDataDTO> GetAll() {
            IEnumerable<WeatherDataEntity> voWeatherData = oRepository.GetWeatherDataService();
            List<GetWeatherDataDTO> voDTOs = new List<GetWeatherDataDTO>();
            foreach (WeatherDataEntity oEntity in voWeatherData) {
                voDTOs.Add(oMapper.EntityToGetDTO(oEntity));
            }
            return voDTOs;
        }
    }
}