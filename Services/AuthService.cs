using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _filePath = Path.Combine(FileSystem.Current.CacheDirectory, "userCreds.json");
        private User _currentUser = new User();
        private bool isLoggedIn { get; set; } = false;

        // Validate user on login
        public bool ValidateUser(string Username, string Password)
        {
            _currentUser = GetUserFromFile();

            if (_currentUser != null && _currentUser.Username == Username && _currentUser.Password == Password)
            {
                return true;
            }
            return false;
        }


        // Save user credentials on first login
        public void SaveUser(string Username, string Password, string PreferredCurrency)
        {
            var newUser = new User(Username, Password, PreferredCurrency);
            var jsonUserCreds = JsonSerializer.Serialize(newUser);
            File.WriteAllText(_filePath, jsonUserCreds);
        }


        // Get user credentials from json file
        public User GetUserFromFile()
        {
            if (File.Exists(_filePath))
            {
                var jsonUserCreds = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<User>(jsonUserCreds);
            }

            return null;
        }

    }
}
