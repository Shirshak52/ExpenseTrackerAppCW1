using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        // ID
        public Guid Id { get; set; } = Guid.NewGuid();

        // Title
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        // Type
        [Required(ErrorMessage = "Please select a type.")]
        public string Type { get; set; }

        // Amount
        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public float Amount { get; set; }

        // Date
        [Required(ErrorMessage = "Please select a date.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Date must be between January 1, 1900 and December 31, 2100.")]
        public DateTime? Date { get; set; }

        // Tag
        [Required(ErrorMessage = "Please provide a tag.")]
        public string Tag { get; set; }

        // Notes
        public string Notes { get; set; }

        // List of Transaction Types
        public static List<string> Types = new List<string>
        {
            "Credit",
            "Debit"
        };

        // List of Available Tags
        public static List<string> Tags = new List<string>
        {
            "Clothes",
            "Drinks",
            "EMI",
            "Food",
            "Fuel",
            "Gadgets",
            "Miscellaneous",
            "Monthly",
            "Party",
            "Yearly"
        };

        // Constructors
        public Transaction(string Title, string Type, float Amount, DateTime? Date, string Tag, string Notes)
        {
            this.Id = Guid.NewGuid();
            this.Title = Title;
            this.Type = Type;
            this.Amount = Amount;
            this.Date = Date;
            this.Tag = Tag;
            this.Notes = Notes;
        }

        public Transaction()
        {
            this.Id = Guid.NewGuid();
            this.Title = null;
            this.Type = null;
            this.Amount = 0.0f;
            this.Date = DateTime.Now;
            this.Tag = null;
            this.Notes = string.Empty;
        }
    }
}
