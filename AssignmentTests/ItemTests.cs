using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void CreateItem_WithValidId_ShouldSetIdCorrectly()
        {
            Item item = new Item(1, "a", 1, DateTime.Now);

            Assert.AreEqual(1, item.ID);
        }

        [TestMethod]
        public void CreateItem_WithValidName_ShouldSetNameCorrectly()
        {
            Item item = new Item(1, "a", 1, DateTime.Now);

            Assert.AreEqual("a", item.Name);
        }

        [TestMethod]
        public void CreateItem_WithValidQuantity_ShouldSetQuantityCorrectly()
        {
            Item item = new Item(2, "a", 1, DateTime.Now);

            Assert.AreEqual(1, item.Quantity);
        }

        [TestMethod]
        public void CreateItem_WithProvidedDate_ShouldSetCreationDateCorrectly()
        {
            DateTime now = DateTime.Now;
            Item item = new Item(2, "a", 1, now);

            Assert.AreEqual(now, item.DateCreated);
        }

        [TestMethod]
        public void CreateItem_WithInvalidValues_ShouldThrowException()
        {
            Assert.ThrowsException<Exception>(
                () => new Item(0, "", 0, DateTime.Now));
        }

        [TestMethod]
        public void CreateItem_WithInvalidValues_ShouldReturnCorrectErrorMessage()
        {
            try
            {
                new Item(0, "", 0, DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedMessage =
                    "ERROR: ID below 1; Quantity below 1; Item name is empty; ";

                Assert.AreEqual(expectedMessage, e.Message);
            }
        }

        [TestMethod]
        public void AddQuantity_WithValidAmount_ShouldIncreaseQuantity()
        {
            Item item = new Item(1, "Pen", 5, DateTime.Now);

            item.AddQuantity(3);

            Assert.AreEqual(8, item.Quantity);
        }

        [TestMethod]
        public void RemoveQuantity_WithValidAmount_ShouldDecreaseQuantity()
        {
            Item item = new Item(1, "Pen", 5, DateTime.Now);

            item.RemoveQuantity(2);

            Assert.AreEqual(3, item.Quantity);
        }
    }
}
