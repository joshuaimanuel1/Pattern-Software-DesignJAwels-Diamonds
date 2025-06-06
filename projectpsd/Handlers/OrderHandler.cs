using System.Collections.Generic;
using projectpsd.Model;
using projectpsd.Repositories;

namespace projectpsd.Handlers
{
    public class OrderHandler
    {
        private TransactionRepository transactionRepository;

        public OrderHandler()
        {
            transactionRepository = new TransactionRepository();
        }

       
        public List<TransactionHeader> GetCustomerOrderHistory(int userId)
        {
            return transactionRepository.GetUserTransactionHistory(userId);
        }

        
        public TransactionHeader GetCustomerTransactionDetail(int transactionId)
        {
            return transactionRepository.GetTransactionDetailById(transactionId);
        }

        
        public string ConfirmPackageReceived(int transactionId, int userId)
        {
            TransactionHeader transaction = transactionRepository.GetById(transactionId);
            if (transaction == null || transaction.UserID != userId)
            {
                return "Transaction not found or you don't have access.";
            }
            if (transaction.TransactionStatus != "Arrived")
            {
                return "Package status is not 'Arrived'.";
            }

            transaction.TransactionStatus = "Done";
            transactionRepository.Update(transaction);
            return "Package confirmed as received. Status changed to Done.";
        }

      
        public string RejectPackage(int transactionId, int userId)
        {
            TransactionHeader transaction = transactionRepository.GetById(transactionId);
            if (transaction == null || transaction.UserID != userId)
            {
                return "Transaction not found or you don't have access.";
            }
            if (transaction.TransactionStatus != "Arrived")
            {
                return "Package status is not 'Arrived'.";
            }

            transaction.TransactionStatus = "Rejected";
            transactionRepository.Update(transaction);
            return "Package rejected. Status changed to Rejected.";
        }


        
        public List<TransactionHeader> GetUnfinishedOrdersForAdmin()
        {
            return transactionRepository.GetUnfinishedOrders();
        }

        
        public string ConfirmPayment(int transactionId)
        {
            TransactionHeader transaction = transactionRepository.GetById(transactionId);
            if (transaction == null)
            {
                return "Transaction not found.";
            }
            if (transaction.TransactionStatus != "Payment Pending")
            {
                return "Transaction status is not 'Payment Pending'.";
            }

            transaction.TransactionStatus = "Shipment Pending";
            transactionRepository.Update(transaction);
            return "Payment confirmed. Status changed to Shipment Pending.";
        }

        
        public string ShipPackage(int transactionId)
        {
            TransactionHeader transaction = transactionRepository.GetById(transactionId);
            if (transaction == null)
            {
                return "Transaction not found.";
            }
            if (transaction.TransactionStatus != "Shipment Pending")
            {
                return "Transaction status is not 'Shipment Pending'.";
            }

            transaction.TransactionStatus = "Arrived";
            transactionRepository.Update(transaction);
            return "Package shipped. Status changed to Arrived.";
        }

        
        public List<TransactionHeader> GetSuccessfulTransactionsForReport()
        {
            return transactionRepository.GetSuccessfulTransactions();
        }
    }
}