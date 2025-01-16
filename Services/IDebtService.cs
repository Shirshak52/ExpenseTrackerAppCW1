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

        // Create
        public void AddNewDebt(string Title, float Amount, DateTime? Date, string Source, DateTime? DueDate);

        // Read
        public IEnumerable<Debt> GetAllDebts();

        public void ToggleIsPending(Debt debt);
    }
}
