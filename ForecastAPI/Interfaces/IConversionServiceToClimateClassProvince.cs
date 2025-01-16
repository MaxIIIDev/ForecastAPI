using ForecastAPI.Models;

namespace ForecastAPI.Interfaces
{
    public interface IConversionServiceToClimateClassProvince
    {
        List<ClimaProvincia> ConvertApiResponseAtClimaProvincia(Root responseFromAPI);
    }
}
