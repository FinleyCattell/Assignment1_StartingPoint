using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests
{
    [TestClass]
    public class TransactionLogManagerTests
    {
        [TestMethod]
        public void AddTransaction_WhenCalled_ShouldStoreTransaction()
        {
            TransactionLogManager manager = new TransactionLogManager();
            TransactionLogEntry entry =
                new TransactionLogEntry("Item Added", 1, "Pen", 1.0, 5, "Graham", DateTime.Now);

            manager.AddTransactionLog(entry);

            Assert.AreEqual(1, manager.GetTransactionLog().Count);
        }

        [TestMethod]
        public void GetTransactionLog_WhenTransactionsExist_ShouldReturnAllTransactions()
        {
            TransactionLogManager manager = new TransactionLogManager();
            manager.AddTransactionLog(
                new TransactionLogEntry("Item Added", 1, "Pen", 1.0, 5, "Graham", DateTime.Now));

            Assert.AreEqual(1, manager.GetTransactionLog().Count);
        }
    }
}
