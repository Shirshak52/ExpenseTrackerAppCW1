using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public interface IDebtService
    {
        public void Initialize();

        // CREATE
        // Add new debt to JSON file
        public void AddNewDebt(string Title, float Amount, DateTime? Date, string Source, DateTime? DueDate);

        
        // READ
        // Get list of all debts
        public IEnumerable<Debt> GetAllDebts();


        // UPDATE
        // Toggle 'IsPending' to clear a debt
        public void ToggleIsPending(Debt debt);
    }
}
