using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentTests
{
    [TestClass]
    public class StockManagerTests
    {
        [TestMethod]
        public void AddItem_WithNewId_ShouldAddItemToStock()
        {
            StockManager manager = new StockManager();

            Item item = manager.AddItem(1, "Pencil", 10);

            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void AddItem_WithDuplicateId_ShouldThrowException()
        {
            StockManager manager = new StockManager();
            manager.AddItem(1, "Pencil", 10);

            Assert.ThrowsException<System.Exception>(
                () => manager.AddItem(1, "Pen", 5));
        }

        [TestMethod]
        public void FindItem_WhenItemExists_ShouldReturnItem()
        {
            StockManager manager = new StockManager();
            manager.AddItem(1, "Pencil", 10);

            Item result = manager.FindItem(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindItem_WhenItemDoesNotExist_ShouldReturnNull()
        {
            StockManager manager = new StockManager();

            Item result = manager.FindItem(99);

            Assert.IsNull(result);
        }
    }
}
