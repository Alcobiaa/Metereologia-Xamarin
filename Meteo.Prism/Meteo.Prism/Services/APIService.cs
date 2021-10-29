using Meteo.Prism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Prism.Services
{
    public class APIService : IAPIService
    {
        public async Task<bool> Login(string username, string password)
        {
            var client = new HttpClient();

            var loginBody = new User
            {
                Password = password,
                Username = username
            };

            var json = JsonConvert.SerializeObject(loginBody);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://imobilar2021.azurewebsites.net/api/users", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string username, string password, string address, int fiscalNumber, int citizenCardNumber, int age, string role)
        {
            var client = new HttpClient();

            var model = new RegisterUser
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                Address = address,
                FiscalNumber = fiscalNumber,
                CitizenCardNumber = citizenCardNumber,
                Age = age,
                Role = "Admin"
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://imobilar2021.azurewebsites.net/api/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<ChangeUser> GetUser(string username)
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://imobilar2021.azurewebsites.net/api/modifyuser" + $"?username={username}");

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                var changedUser = JsonConvert.DeserializeObject<ChangeUser>(contentString);

                if (changedUser == null)
                {
                    return null;
                }
                else
                {
                    return changedUser;
                }
            }

            return null;
        }

        public async Task<ChangeUser> UserPropertiesChange(string firstName, string lastName, string address, int fiscalNumber, int citizenCardNumber, int age)
        {
            string savedUsername = string.Empty;
            var properties = Xamarin.Forms.Application.Current.Properties;

            if (properties.ContainsKey("username"))
            {
                savedUsername = (string)properties["username"];
            }

            var client = new HttpClient();

            var model = new ChangeUser
            {
                FirstName = firstName,
                LastName = lastName,
                Username = savedUsername,
                Address = address,
                FiscalNumber = fiscalNumber,
                CitizenCardNumber = citizenCardNumber,
                Age = age,
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync("https://imobilar2021.azurewebsites.net/api/modifyuser", content);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                var changedUser = JsonConvert.DeserializeObject<ChangeUser>(contentString);

                if (changedUser == null)
                {
                    return null;
                }
                else
                {
                    return changedUser;
                }
            }

            return null;
        }
    }
}
