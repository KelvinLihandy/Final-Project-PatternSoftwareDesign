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

        // ==================== NEW METHODS FOR MY ORDERS PAGE (NOMOR 11) ====================

        /// <summary>
        /// Get all transactions for a specific user (for My Orders page)
        /// </summary>
        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return TransactionHeaderRepository.GetTransactionsByUserId(userId);
        }

        /// <summary>
        /// Update transaction status (for Confirm Package and Reject Package buttons)
        /// </summary>
        public static bool UpdateTransactionStatus(int transactionId, string status)
        {
            TransactionHeader header = GetTransactionHeader(transactionId);
            if (header != null)
            {
                return TransactionHeaderRepository.SetTransactionStatus(header, status);
            }
            return false;
        }

        // ==================== METHOD FOR NOMOR 12 - COMMENTED OUT ====================
        // TODO: Uncomment this when TransactionDetailView class is created (for teammate)

        /*
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
        */
    }
}