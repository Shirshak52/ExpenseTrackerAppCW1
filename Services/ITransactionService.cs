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

        // CREATE
        // Add new transaction to JSON file
        public void AddNewTransaction(string Title, string Type, float Amount, DateTime? Date, string Tag, string Notes);


        // READ
        // Get list of all transactions
        public IEnumerable<Transaction> GetAllTransactions();

        // Get list of available tags
        public List<string> GetAllTags();

        // Get list of types
        public List<string> GetAllTypes();
    }
}
