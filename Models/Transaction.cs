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
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select a type.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter an amount.")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please provide a tag.")]
        public string Tag { get; set; }

        public string Notes { get; set; }

        public Transaction(string Title, string Type, float Amount, DateTime Date, string Tag, string Notes)
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
