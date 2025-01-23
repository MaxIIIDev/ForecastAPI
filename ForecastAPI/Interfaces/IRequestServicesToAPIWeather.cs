using ForecastAPI.Models;

namespace ForecastAPI.Interfaces
{
    public interface IRequestServicesToAPIWeather
    {
        public Task<Root> GetDataFromAPI(double lat, double lon);
        public Task<Root> GetDataFromAPI(string cityName);
        public Task<Root> GetDataFromAPINow(string cityName);
    }
}
