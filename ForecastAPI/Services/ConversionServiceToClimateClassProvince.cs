using ForecastAPI.Interfaces;
using ForecastAPI.Models;


namespace ForecastAPI.Services
{
    public class ConversionServiceToClimateClassProvince : IConversionServiceToClimateClassProvince
    {
        public List<ClimaProvincia> ConvertApiResponseAtClimaProvincia(Root responseFromAPI, Root? responseFromApiNow)
        {

            List<ClimaProvincia> returnAllForecastDay = new List<ClimaProvincia>();

            string getNameByApiData = responseFromAPI.location.name;

            foreach (var forecastDay in responseFromAPI.forecast.forecastday)
            {
                ClimaProvincia climaProvincia = new ClimaProvincia();

                //Obtener la fecha y agregarla al tipo de clase               

                climaProvincia.date = DateTime.ParseExact(forecastDay.date, "yyyy-MM-dd", null);

                //Asignar el nombre ya que no varia
                climaProvincia.name = getNameByApiData;

                //Obtener y asignar latitud

                climaProvincia.latitude = responseFromAPI.location.lat;

                //Obtener y asignar longitud

                climaProvincia.longitude = responseFromAPI.location.lon;

                //si viene info de la temperatura actual la añade

                if (responseFromApiNow != null)
                {
                    climaProvincia.temperatureNow = responseFromApiNow.current.temp_c;
                    climaProvincia.conditionTextNow = responseFromAPI.current.condition.text;
                }


                //obtener temperatura maxima del dia individual
                 climaProvincia.maxTemperature = forecastDay.day.maxtemp_c;

                //obtener temperatura minima del dia individual

                climaProvincia.minTemperature = forecastDay.day.mintemp_c;
                //obtener precipitacion del dia individual

                climaProvincia.precipitation = forecastDay.day.totalprecip_mm;
                //obtener viento del dia individual

                
                climaProvincia.wind = forecastDay.day.maxwind_kph;

                //obtener imagen del dia individual

                
                climaProvincia.image = forecastDay.day.condition.icon;

                //obtener la imagen que va debajo del texto

            
                climaProvincia.textImage = forecastDay.day.condition.text;

                //agregar la imagen a la lista

                returnAllForecastDay.Add(climaProvincia);
            }

            return returnAllForecastDay;
        }
    }
}
