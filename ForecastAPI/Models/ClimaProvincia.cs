﻿namespace ForecastAPI.Models
{
    public class ClimaProvincia
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double? temperatureNow { get; set; }
        public double maxTemperature { get; set; }
       
        public double minTemperature { get; set; }
        public double precipitation { get; set; }
        public double wind { get; set; }
        public string? conditionTextNow { get; set; }
        public string image { get; set; }
        public string imageNow { get; set; }
        public string textImage { get; set; }
        

        public ClimaProvincia() { }

        public ClimaProvincia(
            DateTime date,
            string name,
            double latitude,
            double longitude,
            double maxTemperature,
            double temperatureNow,
            double minTemperature,
            double precipitation,
            double wind,
            string image,
            string textImage)
        {
            this.date = date;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.maxTemperature = maxTemperature;
            this.minTemperature = minTemperature;
            this.precipitation = precipitation;
            this.wind = wind;
            this.image = image;
            this.textImage = textImage;
        }

       
        

        public override string ToString()
        {
            return $"fecha= {this.date}\n" +
                $"nombre = {this.name}\n " +
                $"latitud = {this.latitude}\n " +
                $"longitud = {this.longitude}\n " +
                $"temperaturaMaxima = {this.maxTemperature}\n" +
                $"temperaturaMinima = {this.minTemperature}\n" +
                $"precipitacion = {this.precipitation}\n " +
                $"viento = {this.wind}\n" +
                $"imagen = {this.image}\n" +
                $"textClima = {this.textImage}";
        }

    }
}
