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
        // Existing methods
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

        // New methods for My Orders page
        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return TransactionHeaderRepository.GetTransactionsByUserId(userId);
        }

        public bool UpdateTransactionStatus(int transactionId, string status)
        {
            TransactionHeader header = GetTransactionHeader(transactionId);
            return TransactionHeaderRepository.SetTransactionStatus(header, status);
        }

        public List<TransactionDetailView> GetTransactionItems(int transactionId)
        {
            List<TransactionDetail> details = TransactionDetailRepository.GetTransactionDetailsByTransactionId(transactionId);
            List<TransactionDetailView> detailViews = new List<TransactionDetailView>();

            foreach (var detail in details)
            {
                MsJewel jewel = MsJewelRepository.GetJewelById(detail.JewelID);

                TransactionDetailView detailView = new TransactionDetailView
                {
                    TransactionID = detail.TransactionID,
                    JewelID = detail.JewelID,
                    JewelName = jewel.JewelName,
                    Quantity = detail.Quantity,
                    JewelPrice = jewel.JewelPrice
                };

                detailViews.Add(detailView);
            }

            return detailViews;
        }
    }
}