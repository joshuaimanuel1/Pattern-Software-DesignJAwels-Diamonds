using System;
using System.Collections.Generic;
using projectpsd.Model;

namespace projectpsd.Factories
{
    public static class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(int userId, string paymentMethod)
        {
            return new TransactionHeader
            {
                UserID = userId,
                TransactionDate = DateTime.Now,
                PaymentMethod = paymentMethod,
                TransactionStatus = "Payment Pending"
            };
        }

        public static List<TransactionDetail> CreateTransactionDetails(List<Cart> cartItems)
        {
            List<TransactionDetail> details = new List<TransactionDetail>();
            foreach (var item in cartItems)
            {
                details.Add(new TransactionDetail
                {
                    JewelID = item.JewelID,
                    Quantity = item.Quantity,
                });
            }
            return details;
        }
    }
}