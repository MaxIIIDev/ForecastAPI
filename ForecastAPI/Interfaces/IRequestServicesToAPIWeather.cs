﻿using ForecastAPI.Models;

namespace ForecastAPI.Interfaces
{
    public interface IRequestServicesToAPIWeather
    {
        public Task<Root> GetDataFromAPI(double lat, double lon);
    }
}
