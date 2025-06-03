using FinalProjectPSD.Model;
using FinalProjectPSD.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPSD.Controller
{
    public class TransactionController
    {
        public static TransactionHeader GetTransactionHeaderById(int Id)
        {
            return TransactionHandler.GetTransactionHeaderById(Id);
        }

        public static List<dynamic> GetTransactionDetailDisplay(int Id)
        {
            return TransactionHandler.GetTransactionDetailDisplay(Id);
        }
    }
}