using Meteo.Prism.Helpers;
using Prism.Navigation;

namespace Meteo.Prism.ViewModels
{
    public class AboutUsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AboutUsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.AboutUs;
        }
    }
}
