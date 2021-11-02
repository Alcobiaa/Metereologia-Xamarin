using Meteo.Prism.Helpers;
using Meteo.Prism.ItemViewModels;
using Meteo.Prism.Models;
using Meteo.Prism.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Meteo.Prism.ViewModels
{
    public class MeteoPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAPIService _apiService;
        private bool _isRunning;
        private string _search;
        private DelegateCommand _searchCommand;
        private List<string> _cities = new List<string> { "Lisbon", "Madrid", "Paris", "London", "Rome", "Amsterdam", "Brussels", "Berlin", "Zurich", "Dublin", "Glasgow", "Copenhagen", "Prague", "Vienna", "Budapest" };
        private ObservableCollection<MeteoItemViewModel> _weather;
        private List<WeatherResponse> _myWeather;

        public MeteoPageViewModel(INavigationService navigationService,
            IAPIService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Meteorology;
            LoadWheatherAsync();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowMeteo));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowMeteo();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<MeteoItemViewModel> Weather
        {
            get => _weather;
            set => SetProperty(ref _weather, value);
        }

        private async void LoadWheatherAsync()
        {
            IsRunning = true;

            var myList = new List<WeatherResponse>();

            foreach (string city in _cities)
            {
                Response response = await _apiService.GetWeather<WeatherResponse>(city);

                if (!response.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                    return;
                }

                myList.Add((WeatherResponse)response.Result);
            }

            IsRunning = false;

            _myWeather = new List<WeatherResponse>(myList);
            ShowMeteo();
        }

        private void ShowMeteo()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Weather = new ObservableCollection<MeteoItemViewModel>(_myWeather.Select(p => new MeteoItemViewModel(_navigationService)
                {
                    Coord = p.Coord,
                    Weather = p.Weather,
                    Base = p.Base,
                    Main = p.Main,
                    Visibility = p.Visibility,
                    Wind = p.Wind,
                    Clouds = p.Clouds,
                    Dt = p.Dt,
                    Sys = p.Sys,
                    TimeZone = p.TimeZone,
                    Id = p.Id,
                    Name = p.Name,
                    Cod = p.Cod
                }).ToList());
            }
            else
            {
                Weather = new ObservableCollection<MeteoItemViewModel>(_myWeather.Select(p => new MeteoItemViewModel(_navigationService)
                {
                    Coord = p.Coord,
                    Weather = p.Weather,
                    Base = p.Base,
                    Main = p.Main,
                    Visibility = p.Visibility,
                    Wind = p.Wind,
                    Clouds = p.Clouds,
                    Dt = p.Dt,
                    Sys = p.Sys,
                    TimeZone = p.TimeZone,
                    Id = p.Id,
                    Name = p.Name,
                    Cod = p.Cod
                })
                .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                .ToList());
            }
        }
    }
}
