using ForecastAPI.Interfaces;
using ForecastAPI.Models;


namespace ForecastAPI.Services
{
    public class ConversionServiceToClimateClassProvince : IConversionServiceToClimateClassProvince
    {
        public List<ClimaProvincia> ConvertApiResponseAtClimaProvincia(Root responseFromAPI)
        {

            List<ClimaProvincia> returnAllForecastDay = new List<ClimaProvincia>();

            string getNameByApiData = responseFromAPI.location.name;

            foreach(var forecastDay in responseFromAPI.forecast.forecastday)
            {
                ClimaProvincia climaProvincia = new ClimaProvincia();

                //Obtener la fecha y agregarla al tipo de clase
                string getDateByApiData = forecastDay.date;
                string format = "yyyy-MM-dd";
                DateTime dateParsed = DateTime.ParseExact(getDateByApiData, format, null);
                climaProvincia.date = dateParsed;

                //Asignar el nombre ya que no varia
                climaProvincia.name = getNameByApiData;

                //Obtener y asignar latitud
                double getLatitudeByApiData = responseFromAPI.location.lat;
                climaProvincia.latitude = getLatitudeByApiData;

                //Obtener y asignar longitud

                double getLongitudeByApiData = responseFromAPI.location.lon;
                climaProvincia.longitude = getLongitudeByApiData;

                //obtener temperatura maxima del dia individual
                double getMaxTemperatureByApiData = forecastDay.day.maxtemp_c;
                climaProvincia.maxTemperature = getMaxTemperatureByApiData;

                //obtener temperatura minima del dia individual

                double getMinTemperatureByApiData = forecastDay.day.mintemp_c;
                climaProvincia.minTemperature = getMinTemperatureByApiData;
                //obtener precipitacion del dia individual

                double getPrecipitationByApiData = forecastDay.day.totalprecip_mm;

                climaProvincia.precipitation = getPrecipitationByApiData;
                //obtener viento del dia individual

                double getWindByApiData = forecastDay.day.maxwind_kph;
                climaProvincia.wind = getWindByApiData;

                //obtener imagen del dia individual

                string getImageByApiData = forecastDay.day.condition.icon;
                climaProvincia.image = getImageByApiData;

                //obtener la imagen que va debajo del texto

                string getTextImageByApiData = forecastDay.day.condition.text;
                climaProvincia.textImage = getTextImageByApiData;

                //agregar la imagen a la lista

                returnAllForecastDay.Add(climaProvincia);
            }

            return returnAllForecastDay;
        }
    }
}
