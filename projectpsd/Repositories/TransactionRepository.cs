using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using projectpsd.Model;

namespace projectpsd.Repositories
{
    public class TransactionRepository : BaseRepository<TransactionHeader>
    {
        public List<TransactionHeader> GetUserTransactionHistory(int userId)
        {
            return db.TransactionHeaders
                     .Include(th => th.TransactionDetails.Select(td => td.MsJewel))
                     .Where(th => th.UserID == userId)
                     .OrderByDescending(th => th.TransactionDate)
                     .ToList();
        }

        public TransactionHeader GetTransactionDetailById(int transactionId)
        {
            return db.TransactionHeaders
                     .Include(th => th.TransactionDetails.Select(td => td.MsJewel))
                     .FirstOrDefault(th => th.TransactionID == transactionId);
        }

        public List<TransactionHeader> GetUnfinishedOrders()
        {
            return db.TransactionHeaders
                     .Where(th => th.TransactionStatus != "Done" && th.TransactionStatus != "Rejected")
                     .OrderBy(th => th.TransactionDate)
                     .ToList();
        }

        public List<TransactionHeader> GetSuccessfulTransactions()
        {
            return db.TransactionHeaders
                     .Include(th => th.TransactionDetails.Select(td => td.MsJewel))
                     .Where(th => th.TransactionStatus == "Done")
                     .OrderByDescending(th => th.TransactionDate)
                     .ToList();
        }

        public void AddNewTransaction(TransactionHeader header, List<TransactionDetail> details)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.TransactionHeaders.Add(header);
                    db.SaveChanges();

                    foreach (var detail in details)
                    {
                        detail.TransactionID = header.TransactionID;

                        db.TransactionDetails.Add(detail);
                    }
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}