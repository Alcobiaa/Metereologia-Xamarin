using Meteo.Prism.Interfaces;
using Meteo.Prism.Resources;
using System.Globalization;
using Xamarin.Forms;

namespace Meteo.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }

        public static string Accept => Resource.Accept;

        public static string Login => Resource.Login;

        public static string Error => Resource.Error;

        public static string Password => Resource.Password;

        public static string Username => Resource.Username;

        public static string FirstName => Resource.FirstName;

        public static string LastName => Resource.LastName;

        public static string Age => Resource.Age;

        public static string FiscalNumber => Resource.FiscalNumber;

        public static string CitizenCardNumber => Resource.CitizenCardNumber;

        public static string Address => Resource.Address;

        public static string Register => Resource.Register;

        public static string ModifyUser => Resource.ModifyUser;

        public static string Meteorology => Resource.Meteorology;

        public static string AboutUs => Resource.AboutUs;

        public static string Date => Resource.Date;

        public static string Version => Resource.Version;

        public static string Author => Resource.Author;

        public static string Update => Resource.Update;
    }
}
