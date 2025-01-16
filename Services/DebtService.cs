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
    public class DebtService : IDebtService
    {
        private readonly string _filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "debts.json");
        private List<Debt> _debts;

        public DebtService()
        {
            Initialize();
        }

        // Add a new transaction to the list, then flush it to the json file
        public void AddNewDebt(string Title, float Amount, DateTime? Date, string Source, DateTime? DueDate)
        {
            Debt newDebt = new Debt(Title, Amount, Date, Source, DueDate);
            _debts.Add(newDebt);
            Flush();
        }

        // Get all transactions from the list, ordered by Date
        public IEnumerable<Debt> GetAllDebts()
        {
            return _debts;
        }


        // Get all transactions from the json file on startup
        public void Initialize()
        {
            // If the json file exists
            if (File.Exists(_filePath))
            {
                var jsonDebts = File.ReadAllText(_filePath);
                _debts = JsonSerializer.Deserialize<List<Debt>>(jsonDebts) ?? null;
            }

            // If the json file does not exist
            else
            {
                _debts = new();
            }
        }

        // Update the json file when a transaction is added
        private void Flush()
        {
            var jsonDebts = JsonSerializer.Serialize(_debts);
            File.WriteAllText(_filePath, jsonDebts);
        }

        public void ToggleIsPending(Debt debt)
        {
            debt.IsPending = false;
            Flush();
        }
    }
}
