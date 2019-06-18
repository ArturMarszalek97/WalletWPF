using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class TransactionVM
    {
        private static ObservableCollection<Transaction> list_of_transactions = new ObservableCollection<Transaction>();

        public static void AddNewTransaction(Transaction transaction)
        {
            list_of_transactions.Add(transaction);
        }

        public static ObservableCollection<Transaction> GetTransactions()
        {
            if(list_of_transactions.Count == 0)
            {
                return null;
            }
            return list_of_transactions;
        }

        public static void DeleteTransaction(int id)
        {
            list_of_transactions.RemoveAt(id);
        }

        internal static void DeleteTransaction(Transaction transaction)
        {
            list_of_transactions.Remove(transaction);
        }
    }
}
