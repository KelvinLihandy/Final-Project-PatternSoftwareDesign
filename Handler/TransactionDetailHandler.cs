using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;

namespace FinalProjectPSD.Handler
{
    public class TransactionDetailHandler
    {
        public static List<object> GetTransactionDetails(int transactionId)
        {
            var details = TransactionDetailRepository.GetTransactionDetails(transactionId);

            // Proyeksikan hanya JewelName dan Quantity
            var result = details.Select(d => new
            {
                JewelName = d.MsJewel.JewelName,
                Quantity = d.Quantity
            }).Cast<object>().ToList();

            return result;
        }
    }
}

