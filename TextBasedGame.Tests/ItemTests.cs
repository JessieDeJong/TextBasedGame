namespace TextBasedAdventure.Tests
{
    [TestClass]
    public sealed class ItemTest
    {
        private Item item = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            item = new Item();
        }

        [TestMethod]
        public void Constructor_ValidInput_CreatesNonNullItem()
        {
            string id = "key";
            string description = "A golden key";
            var localItem = new Item { Id = id, Description = description };

            Assert.IsNotNull(localItem);
        }

        [TestMethod]
        public void Constructor_ValidInput_SetsIdCorrectly()
        {
            string id = "key";
            string description = "A golden key";
            var localItem = new Item { Id = id, Description = description };

            Assert.AreEqual(id, localItem.Id);
        }

        [TestMethod]
        public void Constructor_ValidInput_SetsDescriptionCorrectly()
        {
            string id = "key";
            string description = "A shiny golden key";
            var localItem = new Item { Id = id, Description = description };

            Assert.AreEqual(description, localItem.Description);
        }

        [TestMethod]
        public void Constructor_Default_CreatesNonNullItem()
        {
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Constructor_Default_SetsIdToNull()
        {
            Assert.IsNull(item.Id);
        }

        [TestMethod]
        public void Constructor_Default_SetsDescriptionToNull()
        {
            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_ValidId_UpdatesIdToSameValue()
        {
            string id = "sword";
            item.Id = id;

            Assert.AreEqual(id, item.Id);
        }

        [TestMethod]
        public void SetDescription_ValidDescription_UpdatesDescriptionToSameValue()
        {
            string description = "A sharp sword";
            item.Description = description;

            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void SetId_NullId_SetsIdToNull()
        {
            item.Id = null;

            Assert.IsNull(item.Id);
        }

        [TestMethod]
        public void SetDescription_NullDescription_SetsDescriptionToNull()
        {
            item.Description = null;

            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_EmptyId_SetsIdToEmptyString()
        {
            item.Id = "";

            Assert.AreEqual("", item.Id);
        }

        [TestMethod]
        public void SetDescription_EmptyDescription_SetsDescriptionToEmptyString()
        {
            item.Description = "";

            Assert.AreEqual("", item.Description);
        }
    }
}