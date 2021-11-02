using Meteo.Prism.Models;
using Meteo.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace Meteo.Prism.ItemViewModels
{
    public class MeteoItemViewModel : WeatherResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectWheatherCommand;

        public MeteoItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectWheatherCommand => _selectWheatherCommand ?? (_selectWheatherCommand = new DelegateCommand(SelectWheatherAsync));

        private async void SelectWheatherAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                {"wheather", this }
            };

            await _navigationService.NavigateAsync(nameof(MeteoDetailPage), parameters);
        }
    }
}
