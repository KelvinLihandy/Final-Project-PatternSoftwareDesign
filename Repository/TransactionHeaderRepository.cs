using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Repository
{
	public class TransactionHeaderRepository
	{
		private static DatabaseJewel db = Singleton.GetDatabase();

		public static List<TransactionHeader> GetTransactionHeaders()
		{
			return (from header in db.TransactionHeaders 
					where (header.TransactionStatus != "Done" && header.TransactionStatus != "Rejected") 
					select header).ToList();
		}

		public static TransactionHeader GetTransactionHeader(int transactionId)
		{
			return (from header in db.TransactionHeaders
					where header.TransactionID == transactionId
					select header).FirstOrDefault();
		}

		public static bool SetTransactionStatus(TransactionHeader header, string status)
		{
			header.TransactionStatus = status;
			return db.SaveChanges() > 0;
		}

		public static List<TransactionHeader> GetData()
		{
			DatabaseJewel db = new DatabaseJewel();
			return db.TransactionHeaders.ToList();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .OrderByDescending(t => t.TransactionDate)
                     .ToList();
        }
    }
}