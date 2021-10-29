using Meteo.Prism.Helpers;
using Meteo.Prism.Services;
using Meteo.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace Meteo.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IAPIService _apiService;
        private DelegateCommand _loginCommand;
        private DelegateCommand _registerCommand;
        private string _password;

        public LoginPageViewModel(INavigationService navigationService, IAPIService apiService) : base(navigationService)
        {
            Title = Languages.Login;
            _apiService = apiService;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));

        public string Username { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Username))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                Password = string.Empty;
                return;
            }

            var isAuth = await _apiService.Login(Username, Password);

            if (isAuth)
            {
                var properties = Xamarin.Forms.Application.Current.Properties;

                if (!properties.ContainsKey("username"))
                {
                    properties.Add("username", Username);
                }
                else
                {
                    properties["username"] = Username;
                }

                await NavigationService.NavigateAsync($"/{nameof(MeteoMasterDetailPage)}/NavigationPage/{nameof(MeteoPage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Your password or email is incorrect", "Accept");
            }
        }

        private async void Register()
        {
            await NavigationService.NavigateAsync("NavigationPage/RegisterPage");
        }
    }
}
