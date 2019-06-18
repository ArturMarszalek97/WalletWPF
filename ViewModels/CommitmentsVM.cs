using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class CommitmentsVM
    {
        private static ObservableCollection<Commitment> list_of_commitments;

        public static void InitListOfCommitments()
        {
            list_of_commitments = new ObservableCollection<Commitment>();
        }

        public static void AddNewCommitment(Commitment commitment)
        {
            list_of_commitments.Add(commitment);
        }

        public static ObservableCollection<Commitment> GetCommitments()
        {
            return list_of_commitments;
        }

        internal static void DeleteCommitment(int id)
        {
            list_of_commitments.RemoveAt(id);
        }
    }
}
