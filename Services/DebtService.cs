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
        // File path of JSON file where debts are stored
        private readonly string _filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "debts.json");
        
        // List to store all debts from JSON file
        private List<Debt> _debts;

        // Constructor
        public DebtService()
        {
            Initialize();
        }

        // Add a new debt to the list, then save the list to the JSON file
        public void AddNewDebt(string Title, float Amount, DateTime? Date, string Source, DateTime? DueDate)
        {
            Debt newDebt = new Debt(Title, Amount, Date, Source, DueDate);
            _debts.Add(newDebt);
            Flush();
        }

        // Get all debts from the list
        public IEnumerable<Debt> GetAllDebts()
        {
            return _debts;
        }


        // Get all debts from JSON file
        // If the JSON file does not exist or is empty, set '_debts' to an empty list
        public void Initialize()
        {
            if (File.Exists(_filePath))
            {
                var jsonDebts = File.ReadAllText(_filePath);
                _debts = JsonSerializer.Deserialize<List<Debt>>(jsonDebts) ?? null;
            }
            else
            {
                _debts = new();
            }
        }

        // Serialize list of debts into JSON string and write it into JSON file
        private void Flush()
        {
            var jsonDebts = JsonSerializer.Serialize(_debts);
            File.WriteAllText(_filePath, jsonDebts);
        }

        // Toggle 'IsPending' to false for clearning a debt
        public void ToggleIsPending(Debt debt)
        {
            debt.IsPending = false;
            Flush();
        }
    }
}
