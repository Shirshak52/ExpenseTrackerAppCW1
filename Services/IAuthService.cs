using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    interface IAuthService
    {
        // CREATE
        // Save user details to JSON file
        public void SaveUser(string Username, string Password, string PreferredCurrency);


        // READ
        // Get user details from file
        public User GetUserFromFile();

        // Get list of available currencies
        public List<string> GetAvailableCurrencies();


        // HELPERS
        // Validate user for login
        public bool ValidateUser(string Password);

        // Check if user exists
        public bool UserExists();


    }
}
