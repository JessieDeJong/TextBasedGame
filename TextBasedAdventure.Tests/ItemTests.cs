namespace TextBasedAdventure.Tests
{
    [TestClass]
    public sealed class ItemTests
    {
        private Item item = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            item = new Item();
        }

        [TestMethod]
        public void Constructor_ValidInput_CreatesNonNullItem()
        {
            // Arrange
            string id = "key";
            string description = "A golden key";

            // Act
            var localItem = new Item { Id = id, Description = description };

            // Assert
            Assert.IsNotNull(localItem);
        }

        [TestMethod]
        public void Constructor_ValidInput_SetsIdCorrectly()
        {
            // Arrange
            string id = "key";
            string description = "A golden key";

            // Act
            var localItem = new Item { Id = id, Description = description };

            // Assert
            Assert.AreEqual(id, localItem.Id);
        }

        [TestMethod]
        public void Constructor_ValidInput_SetsDescriptionCorrectly()
        {
            // Arrange
            string id = "key";
            string description = "A shiny golden key";

            // Act
            var localItem = new Item { Id = id, Description = description };

            // Assert
            Assert.AreEqual(description, localItem.Description);
        }

        [TestMethod]
        public void Constructor_Default_CreatesNonNullItem()
        {
            // Assert
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Constructor_Default_SetsIdToNull()
        {
            // Assert
            Assert.IsNull(item.Id);
        }

        [TestMethod]
        public void Constructor_Default_SetsDescriptionToNull()
        {
            // Assert
            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_ValidId_UpdatesIdToSameValue()
        {
            // Arrange
            string id = "sword";

            // Act
            item.Id = id;

            // Assert
            Assert.AreEqual(id, item.Id);
        }

        [TestMethod]
        public void SetDescription_ValidDescription_UpdatesDescriptionToSameValue()
        {
            // Arrange
            string description = "A sharp sword";

            // Act
            item.Description = description;

            // Assert
            Assert.AreEqual(description, item.Description);
        }

        [TestMethod]
        public void SetId_NullId_SetsIdToNull()
        {
            // Act
            item.Id = null;

            // Assert
            Assert.IsNull(item.Id);
        }

        [TestMethod]
        public void SetDescription_NullDescription_SetsDescriptionToNull()
        {
            // Act
            item.Description = null;

            // Assert
            Assert.IsNull(item.Description);
        }

        [TestMethod]
        public void SetId_EmptyId_SetsIdToEmptyString()
        {
            // Act
            item.Id = "";

            // Assert
            Assert.AreEqual("", item.Id);
        }

        [TestMethod]
        public void SetDescription_EmptyDescription_SetsDescriptionToEmptyString()
        {
            // Act
            item.Description = "";

            // Assert
            Assert.AreEqual("", item.Description);
        }
    }
}
