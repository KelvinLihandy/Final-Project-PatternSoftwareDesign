using FinalProjectPSD.Factory;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace FinalProjectPSD.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            return TransactionHeaderRepository.GetTransactionHeaders();
        }

        public static TransactionHeader GetTransactionHeader(int transactionId)
        {
            return TransactionHeaderRepository.GetTransactionHeader(transactionId);
        }

        public static bool SetConfirmPayment(int transactionId)
        {
            TransactionHeader header = GetTransactionHeader(transactionId);
            return TransactionHeaderRepository.SetTransactionStatus(header, "Shipment Pending");
        }

        public static bool setShipmentPending(int transactionId)
        {
            TransactionHeader header = GetTransactionHeader(transactionId);
            return TransactionHeaderRepository.SetTransactionStatus(header, "Arrived");
        }
    }
}