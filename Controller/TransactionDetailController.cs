using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.Controller
{
    public class TransactionDetailController
    {
        public static List<object> GetTransactionDetail(int transactionId)
        {
            return TransactionDetailHandler.GetTransactionDetails(transactionId);
        }
    }
}
