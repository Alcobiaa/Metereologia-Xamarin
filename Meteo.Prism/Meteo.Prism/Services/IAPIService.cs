using Meteo.Prism.Models;
using System.Threading.Tasks;

namespace Meteo.Prism.Services
{
    public interface IAPIService
    {
        Task<bool> Login(string username, string password);

        Task<bool> RegisterAsync(string firstName, string lastName, string username, string password, string address, int fiscalNumber, int citizenCardNumber, int age, string role);

        Task<ChangeUser> GetUser(string username);

        Task<ChangeUser> UserPropertiesChange(string firstName, string lastName, string address, int fiscalNumber, int citizenCardNumber, int age);
    }
}
