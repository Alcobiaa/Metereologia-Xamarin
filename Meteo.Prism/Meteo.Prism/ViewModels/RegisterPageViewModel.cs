using Meteo.Prism.Helpers;
using Meteo.Prism.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Meteo.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly IAPIService _apiService;
        private string _password;

        public RegisterPageViewModel(INavigationService navigationService,
            IAPIService apiService) : base(navigationService)
        {
            Title = Languages.Register;
            _apiService = apiService;
        }

        public DelegateCommand RegisterCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var isSucess = await _apiService.RegisterAsync(FirstName, LastName, Username, Password, Address, FiscalNumber, CitizenCardNumber, Age, Role);

                    if (isSucess)
                    {
                        await App.Current.MainPage.DisplayAlert("OK", "Registered successfully", Languages.Accept);
                        await NavigationService.NavigateAsync($"/NavigationPage/LoginPage");
                        //await NavigationService.NavigateAsync("/LoginPage");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Languages.Error, "Retry later", Languages.Accept);
                    }
                });
            }
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Address { get; set; }

        public int FiscalNumber { get; set; }

        public int CitizenCardNumber { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }
    }
}
