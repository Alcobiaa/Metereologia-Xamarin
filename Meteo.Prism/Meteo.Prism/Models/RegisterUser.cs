namespace Meteo.Prism.Models
{
    public class RegisterUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int FiscalNumber { get; set; }

        public int CitizenCardNumber { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }
    }
}
