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
        private readonly string _filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "userCreds.json");
        private User _currentUser;
        private bool isLoggedIn { get; set; } = false;

        public AuthService()
        {
            Initialize();
        }

        // Validate user on login
        public bool ValidateUser(string Username, string Password)
        {
            if (_currentUser != null && _currentUser.Username == Username && _currentUser.Password == Password)
            {
                return true;
            }
            return false;
        }


        // Save user credentials on first login
        public void SaveUser(string Username, string Password, string PreferredCurrency)
        {
            _currentUser = new User(Username, Password, PreferredCurrency);
            Flush();
        }

        public User GetUserFromFile()
        {
            return _currentUser;
        }


        // Get user credentials from json file
        public void Initialize()
        {
            // If the json file exists
            if (File.Exists(_filePath))
            {
                var jsonUserCreds = File.ReadAllText(_filePath);
                _currentUser = JsonSerializer.Deserialize<User>(jsonUserCreds) ?? null;
            }

            // If the json file does not exist
            else
            {
                _currentUser = null;
            }
        }




        private void Flush()
        {
            var jsonUserCreds = JsonSerializer.Serialize(_currentUser);
            File.WriteAllText(_filePath, jsonUserCreds);
        }



        public bool UserExists()
        {
            return _currentUser != null;
        }
    }
}
