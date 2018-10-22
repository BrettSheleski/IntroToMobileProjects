﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeatherHub.Models;
using Xamarin.Forms;

namespace WeatherHub.Xamarin.Models
{
    public class ViewWeatherPageViewModel : WeatherHub.Models.ModelBase
    {
        private WeatherResult _weather;

        public ViewWeatherPageViewModel(WeatherHub.Models.ViewWeatherPageModel model)
        {
            this.Model = model;

            Model.Country = "us";
            Model.State = "WI";

            this.GetWeatherCommand = new Command(UpdateWeather);
        }

        public ViewWeatherPageModel Model { get; }
        public ICommand GetWeatherCommand { get; }

        public WeatherResult Weather { get => _weather; private set { _weather = value; OnPropertyChanged(); } }

        public bool IsRunning { get => _isRunning; set { _isRunning = value; OnPropertyChanged(); } }

        private bool _isRunning;
        private async void UpdateWeather()
        {
            try
            {
                IsRunning = true;
                this.Weather = await Model.GetWeather();
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}
