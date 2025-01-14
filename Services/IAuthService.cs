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
        public bool ValidateUser(string Password);

        public void SaveUser(string Username, string Password, string PreferredCurrency);

        public User GetUserFromFile();


        public bool UserExists();
    }
}
