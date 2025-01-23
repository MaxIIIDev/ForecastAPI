using ForecastAPI.Interfaces;
using ForecastAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using System.Text.Json;

namespace ForecastAPI.Services
{
    public class RequestServicesToAPIWeather : IRequestServicesToAPIWeather
    {
        HttpClient httpClient;
        string BASEURL = "https://api.weatherapi.com/v1/forecast.json?";
        string APIKEY = "key=3705c7e1771846bdbfc24459250601";
        public RequestServicesToAPIWeather()
        {
            httpClient = new HttpClient();
        }

        public async Task<Root> GetDataFromAPI(double lat, double lon)
        {
            Root returnData = null;
            try
            {
                string urlFragmentWithLatAndLonRaw = $"q={lat}%20{lon}";
                string urlFragmentWithLatAndLonReadyToGo = urlFragmentWithLatAndLonRaw.Replace(",", "."); //Se realiza la conversion ya que los puntos al pasarlos a string se convierten en coma, y devuelve valores erroneos en geolocalizacion
                string actualDate = DateTime.Now.ToString(); // agregue este fragmento para añadir legibilidad al codigo

                string fullURL = $"{BASEURL}{urlFragmentWithLatAndLonReadyToGo}&days=3&dt={actualDate}&{APIKEY}"; //URL PREPARADA PARA LANZAR LA LLAMADA
                
                HttpResponseMessage? dataFromApiWeather = await httpClient.GetAsync(fullURL); //SE REALIZA LA PETICION A LA API

                dataFromApiWeather.EnsureSuccessStatusCode();   //SE VALIDA SI LA PETICION FUNCIONO; SI NO PUM, EXCEPCION
                
                string readDataFromApiWeather = await dataFromApiWeather.Content.ReadAsStringAsync(); // SE LEE LA INFORMACION DE LA PETICION Y SE PONE EL JSON A STRING

                Root apiDataOpenToWork = JsonSerializer.Deserialize<Root>(readDataFromApiWeather); //SE PARSEA ENTRE COMILLAS A FORMATO C# ACORDE AL MOdelo
                if( apiDataOpenToWork == null )
                {
                    throw new Exception("API don´t return information");
                }
                 returnData = apiDataOpenToWork;    // SE CREO LA VARIABLE DE ESTA FORMA PORQUE ME DIO FIACA PONERLA AFUERA
                
            }
            catch (HttpRequestException httpEx)
            { 
                Debug.WriteLine("Ocurrió un error de red: " + httpEx.Message);  // EXCEPCION POR EL PUM DE LA LINEA 30
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio un error" +
                    "\nServicio= RequestServicesToAPIWeather");
                Debug.WriteLine("Error Message= " + ex.Message);
            }
            return returnData;
        }

        public async Task<Root> GetDataFromAPI(string cityName)
        {
            Root returnData = null;
            try
            {
                string urlFragmentWithCityName = $"q={cityName}";

                string urlFragmentWithCityNameReadyToGo = urlFragmentWithCityName.Replace(" ", "%20"); //Reemplaza los espacios por %20 para que la url interprete que son espacios


                string actualDate = DateTime.Now.ToString(); // agregue este fragmento para añadir legibilidad al codigo

                string fullURL = $"{BASEURL}{urlFragmentWithCityNameReadyToGo}&days=3&dt={actualDate}&{APIKEY}"; //URL PREPARADA PARA LANZAR LA LLAMADA

                HttpResponseMessage? dataFromApiWeather = await httpClient.GetAsync(fullURL); //SE REALIZA LA PETICION A LA API

                dataFromApiWeather.EnsureSuccessStatusCode();   //SE VALIDA SI LA PETICION FUNCIONO; SI NO PUM, EXCEPCION

                string readDataFromApiWeather = await dataFromApiWeather.Content.ReadAsStringAsync(); // SE LEE LA INFORMACION DE LA PETICION Y SE PONE EL JSON A STRING

                Root apiDataOpenToWork = JsonSerializer.Deserialize<Root>(readDataFromApiWeather); //SE PARSEA ENTRE COMILLAS A FORMATO C# ACORDE AL MOdelo
                if (apiDataOpenToWork == null)
                {
                    throw new Exception("API don´t return information");
                }
                returnData = apiDataOpenToWork;    // SE CREO LA VARIABLE DE ESTA FORMA PORQUE ME DIO FIACA PONERLA AFUERA

            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine("Ocurrió un error de red: " + httpEx.Message);  // EXCEPCION POR EL PUM DE LA LINEA 30
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio un error" +
                    "\nServicio= RequestServicesToAPIWeather");
                Debug.WriteLine("Error Message= " + ex.Message);
            }
            return returnData;
        }
        public async Task<Root> GetDataFromAPINow(string cityName)
        {
            Root returnData = null;
            string urlCurrent = "https://api.weatherapi.com/v1/current.json?";
            try
            {
                string urlFragmentWithCityName = $"q={cityName}";

                string urlFragmentWithCityNameReadyToGo = urlFragmentWithCityName.Replace(" ", "%20"); //Reemplaza los espacios por %20 para que la url interprete que son espacios


                string actualDate = DateTime.Now.ToString(); // agregue este fragmento para añadir legibilidad al codigo

                string fullURL = $"{urlCurrent}{urlFragmentWithCityNameReadyToGo}&{APIKEY}"; //URL PREPARADA PARA LANZAR LA LLAMADA

                HttpResponseMessage? dataFromApiWeather = await httpClient.GetAsync(fullURL); //SE REALIZA LA PETICION A LA API

                dataFromApiWeather.EnsureSuccessStatusCode();   //SE VALIDA SI LA PETICION FUNCIONO; SI NO PUM, EXCEPCION

                string readDataFromApiWeather = await dataFromApiWeather.Content.ReadAsStringAsync(); // SE LEE LA INFORMACION DE LA PETICION Y SE PONE EL JSON A STRING

                Root apiDataOpenToWork = JsonSerializer.Deserialize<Root>(readDataFromApiWeather); //SE PARSEA ENTRE COMILLAS A FORMATO C# ACORDE AL MOdelo
                if (apiDataOpenToWork == null)
                {
                    throw new Exception("API don´t return information");
                }
                returnData = apiDataOpenToWork;    // SE CREO LA VARIABLE DE ESTA FORMA PORQUE ME DIO FIACA PONERLA AFUERA

            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine("Ocurrió un error de red: " + httpEx.Message);  // EXCEPCION POR EL PUM DE LA LINEA 30
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio un error" +
                    "\nServicio= RequestServicesToAPIWeather");
                Debug.WriteLine("Error Message= " + ex.Message);
            }
            return returnData;
        }

    }
}
