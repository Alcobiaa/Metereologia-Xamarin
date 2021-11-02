using Meteo.Prism.Services;
using Meteo.Prism.ViewModels;
using Meteo.Prism.Views;
using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Meteo.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("NTIxODU0QDMxMzkyZTMzMmUzMEJJRUwrVHhlbXd4UkkwS1NRODNkbGo2NnpnSWY5bTJ4bEJ0Z0dXNHdkdHc9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            //await NavigationService.NavigateAsync($"/{nameof(MeteoMasterDetailPage)}/NavigationPage/{nameof(MeteoPage)}");
            //await NavigationService.NavigateAsync("NavigationPage/AboutUsPage");
            //await NavigationService.NavigateAsync("NavigationPage/MeteoPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<IAPIService, APIService>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<MeteoPage, MeteoPageViewModel>();
            containerRegistry.RegisterForNavigation<MeteoMasterDetailPage, MeteoMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsPage, AboutUsPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<MeteoDetailPage, MeteoDetailPageViewModel>();
        }
    }
}
