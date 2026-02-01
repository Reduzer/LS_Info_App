namespace Entities.DTOs.POST {
    public class PostWeatherDataDTO {
        public PostWeatherDataDTO(string sCity, string sCountry, double dTempC, string sConditionText, double dWindKph, string sWindDir, double dFeelsLikeC) {
            this.sCity = sCity;
            this.sCountry = sCountry;
            this.dTempC = dTempC;
            this.sConditionText = sConditionText;
            this.dWindKph = dWindKph;
            this.sWindDir = sWindDir;
            this.dFeelsLikeC = dFeelsLikeC;
        }
        public string sCity { get; set; }
        public string sCountry { get; set; }
        public double dTempC { get; set; }
        public string sConditionText { get; set; }
        public double dWindKph { get; set; }
        public string sWindDir { get; set; }
        public double dFeelsLikeC { get; set; }
        public DateTime oRecordedAt { get; private set; } = DateTime.Now;
    }
}