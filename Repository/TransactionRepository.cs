using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
    public class TransactionRepository
    {
        private static DatabaseJewel db = Singleton.GetDatabase();

        public static TransactionHeader GetTransactionHeaderById(int Id)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.TransactionID == Id);
        }

        public static List<TransactionDetail> GetTransactionDetailsByHeaderId(int transId)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == transId).ToList();
        }
    }
}