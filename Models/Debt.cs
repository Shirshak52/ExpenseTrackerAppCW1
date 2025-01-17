using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Debt
    {
        // ID
        public Guid Id { get; set; } = Guid.NewGuid();

        // Title
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        // Amount
        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public float Amount { get; set; }

        // Date (when the debt amount was taken)
        [Required(ErrorMessage = "Please select a date.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Date must be between January 1, 1900 and December 31, 2100.")]
        public DateTime? Date { get; set; }

        // Source
        [Required(ErrorMessage = "Please enter a source.")]
        public string Source { get; set; }

        // Due Date
        [Required(ErrorMessage = "Please select a due date.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "Date must be between January 1, 1900 and December 31, 2100.")]
        public DateTime? DueDate { get; set; }

        // Difference between Due Date and Date when debt amount was taken
        // Ensures that Due Date is always in the future of Date
        [Range(0, int.MaxValue, ErrorMessage = "Due date must be on or after the debt date.")]
        public int DateDifference => (DueDate.HasValue && Date.HasValue) ? (DueDate.Value - Date.Value).Days : 0;

        // Status (i.e., Pending or Cleared)
        public bool IsPending { get; set; }

        // Status (Set to 'Pending' If 'IsPending' is true, 'Cleared' if false)
        public string Status => IsPending ? "Pending" : "Cleared";

        // Constructors
        public Debt(string Title, float Amount, DateTime? Date, string Source, DateTime? DueDate)
        {
            this.Id = Guid.NewGuid();
            this.Title = Title;
            this.Amount = Amount;
            this.Date = Date;
            this.Source = Source;
            this.DueDate = DueDate;
            this.IsPending = true;
        }

        public Debt()
        {
            this.Id = Guid.NewGuid();
            this.Title = null;
            this.Amount = 0.0f;
            this.Date = DateTime.Now;
            this.Source = null;
            this.DueDate = DateTime.Now;
            this.IsPending = true;
        }
    }
}
