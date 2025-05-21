using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;


namespace FinalProjectPSD.Repository
{
    public class TransactionDetailRepository
    {
        private static DatabaseJewel db = new DatabaseJewel();

        public static List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            return db.TransactionDetails
                .Where(td => td.TransactionID == transactionId)
                .ToList();
        }
    }
}
