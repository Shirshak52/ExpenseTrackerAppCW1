using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ExpenseTracker.Models;
using System.Security.Cryptography;

namespace ExpenseTracker.Services
{
    public class AuthService : IAuthService
    {
        // File path of JSON file where user details are stored
        private readonly string _filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "userCreds.json");

        // Current user (whose details are in the JSON file)
        private User _currentUser;

        // Constructor
        public AuthService()
        {
            Initialize();
        }

        // Validate user on login
        public bool ValidateUser(string Password)
        {
            if (_currentUser != null && _currentUser.Password == HashPassword(Password))
            {
                return true;
            }
            return false;
        }


        // Save user credentials to JSON file during signup
        public void SaveUser(string Username, string Password, string PreferredCurrency)
        {
            _currentUser = new User(Username, HashPassword(Password), PreferredCurrency);
            Flush();
        }

        // Hash the password before saving to JSON file
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));

        }

        // Get the current user from the JSON file
        public User GetUserFromFile()
        {
            return _currentUser;
        }

        // Get the list of available currencies
        public List<string> GetAvailableCurrencies()
        {
            return User.AvailableCurrencies;
        }


        // Get user details from JSON file on startup
        // If file does not exist or is empty, set '_currentUser' to null
        public void Initialize()
        {
            if (File.Exists(_filePath))
            {
                var jsonUserCreds = File.ReadAllText(_filePath);
                _currentUser = JsonSerializer.Deserialize<User>(jsonUserCreds) ?? null;
            }
            else
            {
                _currentUser = null;
            }
        }


        // Serialize 'User' object into JSON string and write it into JSON file
        private void Flush()
        {
            var jsonUserCreds = JsonSerializer.Serialize(_currentUser);
            File.WriteAllText(_filePath, jsonUserCreds);
        }

        // Check if a user already exists
        public bool UserExists()
        {
            return _currentUser != null;
        }
    }
}
