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
        // File path of JSON file where transactions are stored
        private readonly string _transactionsFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, "transactions.json");

        // List to store all transactions from JSON file
        private List<Transaction> _transactions;

        // List to store all types of transactions (i.e., Debit and Credit)
        private List<string> _types;

        // List to store available tags
        private List<string> _tags;

        // Constructor
        public TransactionService()
        {
            Initialize();
        }

        // Add a new transaction to the list, then save the list to the JSON file
        public void AddNewTransaction(string Title, string Type, float Amount, DateTime? Date, string Tag, string Notes)
        {
            Transaction newTransaction = new Transaction(Title, Type, Amount, Date, Tag, Notes);
            _transactions.Add(newTransaction);
            Flush();
        }

        // Get all transactions from the list
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactions;
        }


        // Get all transactions from JSON file, types, and tags on startup
        // If the transactions JSON file does not exist or is empty, set '_transactions' to an empty list
        public void Initialize()
        {
            if (File.Exists(_transactionsFilePath))
            {
                var jsonTransactions = File.ReadAllText(_transactionsFilePath);
                _transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonTransactions) ?? null;
            }
            else
            {
                _transactions = new();
            }

            _types = Transaction.Types;
            _tags = Transaction.Tags;
        }

        // Serialize list of transactions into JSON string and write it into JSON file
        private void Flush()
        {
            var jsonTransactions = JsonSerializer.Serialize(_transactions);
            File.WriteAllText(_transactionsFilePath, jsonTransactions);
        }

        // Get a list of available tags
        public List<string> GetAllTags()
        {
            return _tags;
        }

        // Get a list of types
        public List<string> GetAllTypes()
        {
            return _types;
        }
    }
}
