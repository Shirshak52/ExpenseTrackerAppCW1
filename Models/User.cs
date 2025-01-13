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
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PreferredCurrency { get; set; }

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
