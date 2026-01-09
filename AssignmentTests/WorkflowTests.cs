using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests
{
    [TestClass]
    public class WorkflowTests
    {
        private StockManager stockManager;
        private TransactionLogManager logManager;

        [TestInitialize]
        public void Setup()
        {
            // Each test starts with a fresh manager
            stockManager = new StockManager();
            logManager = new TransactionLogManager();
        }

        [TestMethod]
        public void AddItem_WhenCalled_ShouldAddItemToStock()
        {
            // Arrange & Act
            Item item = stockManager.AddItem(1, "Notebook", 5);

            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(1, stockManager.NumberOfItemsInStock);
            Assert.AreEqual("Notebook", item.Name);
        }

        [TestMethod]
        public void AddQuantity_WhenCalled_ShouldIncreaseItemQuantity()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);

            // Act
            item.AddQuantity(3);

            // Assert
            Assert.AreEqual(8, item.Quantity);
        }

        [TestMethod]
        public void RemoveQuantity_WhenCalled_ShouldDecreaseItemQuantity()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);

            // Act
            item.RemoveQuantity(2);

            // Assert
            Assert.AreEqual(3, item.Quantity);
        }

        [TestMethod]
        public void TransactionLog_WhenAddingItem_ShouldRecordCorrectTransaction()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);

            // Act
            logManager.AddTransactionLog(
                new TransactionLogEntry("Item Added", item.ID, item.Name, 2.0, item.Quantity, "Graham", DateTime.Now));

            // Assert
            Assert.AreEqual(1, logManager.GetTransactionLog().Count);
            Assert.AreEqual("Notebook", logManager.GetTransactionLog()[0].ItemName);
            Assert.AreEqual("Item Added", logManager.GetTransactionLog()[0].TypeOfTransaction);
        }

        [TestMethod]
        public void TransactionLog_WhenAddingQuantity_ShouldRecordCorrectTransaction()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);
            item.AddQuantity(3);

            // Act
            logManager.AddTransactionLog(
                new TransactionLogEntry("Quantity Added", item.ID, item.Name, 2.0, 3, "Graham", DateTime.Now));

            // Assert
            Assert.AreEqual(1, logManager.GetTransactionLog().Count);
            Assert.AreEqual(3, logManager.GetTransactionLog()[0].Quantity);
            Assert.AreEqual("Quantity Added", logManager.GetTransactionLog()[0].TypeOfTransaction);
        }

        [TestMethod]
        public void TransactionLog_WhenRemovingQuantity_ShouldRecordCorrectTransaction()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);
            item.RemoveQuantity(2);

            // Act
            logManager.AddTransactionLog(
                new TransactionLogEntry("Quantity Removed", item.ID, item.Name, -1, 2, "Graham", DateTime.Now));

            // Assert
            Assert.AreEqual(1, logManager.GetTransactionLog().Count);
            Assert.AreEqual(2, logManager.GetTransactionLog()[0].Quantity);
            Assert.AreEqual("Quantity Removed", logManager.GetTransactionLog()[0].TypeOfTransaction);
        }

        [TestMethod]
        public void RemoveAllQuantity_ShouldReduceQuantityToZero()
        {
            // Arrange
            Item item = stockManager.AddItem(1, "Notebook", 5);

            // Act
            item.RemoveQuantity(5);

            // Assert
            Assert.AreEqual(0, item.Quantity);
        }
    }
}
