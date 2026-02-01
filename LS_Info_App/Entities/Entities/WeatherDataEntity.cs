namespace Entities.Entities
{
    public class WeatherDataEntity
    {
        public WeatherDataEntity() { }

        public WeatherDataEntity(int nId, string sCity, string sCountry, double dTempC, string sConditionText, double dWindKph, string sWindDir, double dFeelsLikeC) {
            this.nId = nId;
            this.sCity = sCity;
            this.sCountry = sCountry;
            this.dTempC = dTempC;
            this.sConditionText = sConditionText;
            this.dWindKph = dWindKph;
            this.sWindDir = sWindDir;
            this.dFeelsLikeC = dFeelsLikeC;
        }

        public WeatherDataEntity(string sCity, string sCountry, double dTempC, string sConditionText, double dWindKph, string sWindDir, double dFeelsLikeC) {
            this.sCity = sCity;
            this.sCountry = sCountry;
            this.dTempC = dTempC;
            this.sConditionText = sConditionText;
            this.dWindKph = dWindKph;
            this.sWindDir = sWindDir;
            this.dFeelsLikeC = dFeelsLikeC;
        }

        public int nId { get; set; }
        public string sCity { get; set; }
        public string sCountry { get; set; }
        public double dTempC { get; set; }
        public string sConditionText { get; set; }
        public double dWindKph { get; set; }
        public string sWindDir { get; set; }
        public double dFeelsLikeC { get; set; }
        public DateTime oRecordedAt { get; private set; } = DateTime.UtcNow;
    }
}