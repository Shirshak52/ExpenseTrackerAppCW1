using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string _transactionsFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, "transactions.json");
        private List<Transaction> _transactions;
        private List<string> _types;
        private List<string> _tags;

        public TransactionService()
        {
            Initialize();
        }

        // Add a new transaction to the list, then flush it to the json file
        public void AddNewTransaction(string Title, string Type, float Amount, DateTime? Date, string Tag, string Notes)
        {
            Transaction newTransaction = new Transaction(Title, Type, Amount, Date, Tag, Notes);
            _transactions.Add(newTransaction);
            Flush();
        }

        // Get all transactions from the list, ordered by Date
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactions;
        }


        // Get all transactions and tags from the json files on startup
        public void Initialize()
        {
            // If the json file exists
            if (File.Exists(_transactionsFilePath))
            {
                var jsonTransactions = File.ReadAllText(_transactionsFilePath);
                _transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonTransactions) ?? null;
            }

            // If the json file does not exist
            else
            {
                _transactions = new();
            }

            _types = Transaction.Types;
            _tags = Transaction.Tags;
        }

        // Update the json file when a transaction is added
        private void Flush()
        {
            var jsonTransactions = JsonSerializer.Serialize(_transactions);
            File.WriteAllText(_transactionsFilePath, jsonTransactions);
        }

        public List<string> GetAllTags()
        {
            return _tags;
        }
        public List<string> GetAllTypes()
        {
            return _types;
        }
    }
}
