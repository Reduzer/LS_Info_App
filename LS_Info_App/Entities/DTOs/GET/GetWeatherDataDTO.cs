namespace Entities.DTOs.GET
{
    public class GetWeatherDataDTO
    {
        public GetWeatherDataDTO(int nId, string sCity, string sCountry, double dTempC, string sConditionText, double dWindKph, string sWindDir, double dFeelsLikeC)
        {
            this.nId = nId;
            this.sCity = sCity;
            this.sCountry = sCountry;
            this.dTempC = dTempC;
            this.sConditionText = sConditionText;
            this.dWindKph = dWindKph;
            this.sWindDir = sWindDir;
            this.dFeelsLikeC = dFeelsLikeC;
        }

        public int nId { get; private set; }
        public string sCity { get; private set; }
        public string sCountry { get; private set; }
        public double dTempC { get; private set; }
        public string sConditionText { get; private set; }
        public double dWindKph { get; private set; }
        public string sWindDir { get; private set; }
        public double dFeelsLikeC { get; private set; }
        public DateTime oRecordedAt { get; private set; } = DateTime.UtcNow;
    }
}