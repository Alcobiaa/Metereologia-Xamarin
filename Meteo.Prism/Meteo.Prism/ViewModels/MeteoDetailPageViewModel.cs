using Meteo.Prism.Models;
using Prism.Navigation;

namespace Meteo.Prism.ViewModels
{
    public class MeteoDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private WeatherResponse _weather;

        public MeteoDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public WeatherResponse Weather
        {
            get => _weather;
            set => SetProperty(ref _weather, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("weather"))
            {
                Weather = parameters.GetValue<WeatherResponse>("weather");
                Title = Weather.Name;
            }
        }
    }
}
