using Meteo.Prism.Helpers;
using Meteo.Prism.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Meteo.Prism.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        private readonly IAPIService _apiService;

        public ModifyUserPageViewModel(INavigationService navigationService,
            IAPIService apiService) : base(navigationService)
        {
            Title = Languages.ModifyUser;
            _apiService = apiService;
            Task.Run(() => this.GetUser()).Wait();
        }

        public DelegateCommand ModifyUserCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var properties = Xamarin.Forms.Application.Current.Properties;

                    if (properties.ContainsKey("username"))
                    {
                        var savedUsername = (string)properties["username"];
                    }

                    var userTask = await _apiService.UserPropertiesChange(FirstName, LastName, Address, FiscalNumber, CitizenCardNumber, Age);

                    if (userTask != null)
                    {
                        await App.Current.MainPage.DisplayAlert("OK", "Change successfully", Languages.Accept);

                        FirstName = userTask.FirstName;
                        LastName = userTask.LastName;
                        Address = userTask.Address;
                        FiscalNumber = userTask.FiscalNumber;
                        CitizenCardNumber = userTask.CitizenCardNumber;
                        Age = userTask.Age;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Languages.Error, "Retry later", Languages.Accept);
                    }
                });
            }
        }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int FiscalNumber { get; set; }

        public int CitizenCardNumber { get; set; }

        public int Age { get; set; }

        public async Task GetUser()
        {
            try
            {
                string savedUsername = string.Empty;
                var properties = Xamarin.Forms.Application.Current.Properties;

                if (properties.ContainsKey("username"))
                {
                    savedUsername = (string)properties["username"];
                }

                var userTask = await _apiService.GetUser(savedUsername);

                FirstName = userTask.FirstName;
                LastName = userTask.LastName;
                Address = userTask.Address;
                FiscalNumber = userTask.FiscalNumber;
                CitizenCardNumber = userTask.CitizenCardNumber;
                Age = userTask.Age;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Retry later", Languages.Accept);
            }
        }
    }
}
