using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public interface ITransactionService
    {
        public void Initialize();

        // Create
        public void AddNewTransaction(string Title, string Type, float Amount, DateTime? Date, string Tag, string Notes);

        // Read
        public IEnumerable<Transaction> GetAllTransactions();
    }
}
