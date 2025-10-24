namespace TextBasedAdventure.Tests
{
    [TestClass]
    public sealed class ItemTest
    {
        [TestMethod]
        public void Constructor_ValidInput_CreatesItem()
        {
            string id = "key";
            string description = "A shiny golden key";
            var item = new Item { Id = id, Description = description };
            Assert.IsNotNull(item);
            Assert.AreEqual(id, item.Id);
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void Constructor_Default_CreatesEmptyItem()
        {
            var item = new Item();
            Assert.IsNotNull(item);
            Assert.IsNull(item.Id);
            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_ValidId_UpdatesId()
        {
            var item = new Item();
            string id = "sword";
            item.Id = id;
            Assert.AreEqual(id, item.Id);
        }

        [TestMethod]
        public void SetDescription_ValidDescription_UpdatesDescription()
        {
            var item = new Item();
            string description = "A sharp sword";
            item.Description = description;
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void SetId_NullId_SetsNull()
        {
            var item = new Item();
            item.Id = null;
            Assert.IsNull(item.Id);
        }

        [TestMethod]
        public void SetDescription_NullDescription_SetsNull()
        {
            var item = new Item();
            item.Description = null;
            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_EmptyId_SetsEmpty()
        {
            var item = new Item();
            item.Id = "";
            Assert.AreEqual("", item.Id);
        }

        [TestMethod]
        public void SetDescription_EmptyDescription_SetsEmpty()
        {
            var item = new Item();
            item.Description = "";
            Assert.AreEqual("", item.Description);
        }
    }
}
