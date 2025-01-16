using ForecastAPI.Interfaces;
using ForecastAPI.Models;
using ForecastAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RootController : ControllerBase
    {
        IRequestServicesToAPIWeather _serviceGetInfoByAPIWeather;
        IConversionServiceToClimateClassProvince _conversionServiceToClimateClassProvince;
        
        public RootController(
            IRequestServicesToAPIWeather serviceGetInfoByAPIWeather,
            IConversionServiceToClimateClassProvince _conversionServiceToClimateClassProvince) 
        {
            this._serviceGetInfoByAPIWeather = serviceGetInfoByAPIWeather;
            this._conversionServiceToClimateClassProvince = _conversionServiceToClimateClassProvince;
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<ClimaProvincia>> GetForecastWithCity(double? lat, double? lon )
        {

            if (lat == null || lon == null) //Latitude and Longitude validation for possibles null values
            {
                string errorMessage = "";
                if(lat == null)
                {
                    errorMessage += "latitude value isn´t can null";
                }
                if(lon == null)
                {
                    errorMessage += "\nLongitude value isn´t can null";
                }
                return BadRequest(errorMessage);
            }

            double latitudeValidated = (double) lat;
            double longitudeValidated = (double)lon;

            

            Root resultsFromApi = await _serviceGetInfoByAPIWeather.GetDataFromAPI(latitudeValidated, longitudeValidated); //Call to the services that provides data from API WEATHER
            if (resultsFromApi == null) // Validation for data from API WEATHER for possibles null values
            {
                return NotFound("Api don´t return info");
            }

            List<ClimaProvincia> forecastList = _conversionServiceToClimateClassProvince.ConvertApiResponseAtClimaProvincia(resultsFromApi); // Call to the conversion services for convert the API DATA to class Clima Provincia

            if(forecastList == null) // Validation for forecast list provides for conversion services
            {
                return NotFound("Api dont provides forecast, so we can´t convert and return results");
            }

            return Ok(forecastList);
        }
    }
}
