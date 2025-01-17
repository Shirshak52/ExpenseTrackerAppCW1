using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class User
    {
        // Username
        [Required(ErrorMessage = "Username cannot be empty.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be 5 to 15 characters long.")]
        public string Username { get; set; }

        // Password
        [Required(ErrorMessage = "Password cannot be empty.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be 8 to 15 characters long.")]
        public string Password { get; set; }

        // Preferred Currency
        [Required(ErrorMessage = "A currency must be selected.")]
        public string PreferredCurrency { get; set; }

        // List of Available Currencies
        public static List<string> AvailableCurrencies = new List<string>
        {
            "NRs.",
            "US$",
            "INR"
        };

        // Constructors
        public User(string Username, string Password, string PreferredCurrency)
        {
            this.Username = Username;
            this.Password = Password;
            this.PreferredCurrency = PreferredCurrency;
        }

        public User()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.PreferredCurrency = string.Empty;
        }
    }
}
