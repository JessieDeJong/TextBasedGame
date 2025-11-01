using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TextBasedAdventure;

namespace TextBasedAdventure.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game _game;
        private Inventory _inventory;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _game = new Game();
            _inventory = new Inventory();
        }

        [TestMethod]
        public void Game_Initializes_IsGameRunning_ShouldBeTrue()
        {
            // Act
            var isRunning = _game.IsGameRunning;

            // Assert
            Assert.IsTrue(isRunning);
        }

        [TestMethod]
        public void BuildWorld_ShouldCreateAllRooms()
        {
            // Act
            var startRoom = _game.BuildWorld();

            // Assert
            Assert.IsNotNull(startRoom);
            Assert.AreEqual(6, _game.AllRooms.Count);
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Entrance Hall"));
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Corridor"));
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Armory"));
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Dragon Lair"));
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Bottomless Pit"));
            Assert.IsTrue(_game.AllRooms.Any(r => r.Name == "Storage Closet"));
        }

        [TestMethod]
        public void BuildWorld_Rooms_ShouldHaveItems()
        {
            // Act
            _game.BuildWorld();

            // Assert
            var armory = _game.AllRooms.First(r => r.Name == "Armory");
            var storage = _game.AllRooms.First(r => r.Name == "Storage Closet");

            Assert.IsTrue(armory.itemList.Any(i => i.Id == "sword"));
            Assert.IsTrue(storage.itemList.Any(i => i.Id == "key"));
        }

        [TestMethod]
        public void BuildWorld_Rooms_ShouldHaveCorrectConnections()
        {
            // Act
            var start = _game.BuildWorld();
            var exit = _game.AllRooms.First(r => r.Name == "Corridor");
            var armory = _game.AllRooms.First(r => r.Name == "Armory");
            var lair = _game.AllRooms.First(r => r.Name == "Dragon Lair");
            var pit = _game.AllRooms.First(r => r.Name == "Bottomless Pit");
            var storage = _game.AllRooms.First(r => r.Name == "Storage Closet");

            // Assert
            Assert.AreEqual(exit, start.Paths[Direction.North]);
            Assert.AreEqual(start, exit.Paths[Direction.South]);
            Assert.AreEqual(armory, start.Paths[Direction.South]);
            Assert.AreEqual(lair, armory.Paths[Direction.South]);
            Assert.AreEqual(pit, start.Paths[Direction.West]);
            Assert.AreEqual(storage, start.Paths[Direction.East]);
        }

        [TestMethod]
        public void Room_Take_ShouldMoveItemToInventory()
        {
            // Arrange
            _game.BuildWorld();
            var armory = _game.AllRooms.First(r => r.Name == "Armory");
            var sword = armory.checkItemInList("sword");

            // Act
            var result = armory.Take(_inventory, sword);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(armory.itemList.Contains(sword));
            Assert.IsTrue(_inventory.isItemInList("sword"));
        }

        [TestMethod]
        public void Room_AllItems_ShouldReturnCorrectString()
        {
            // Arrange
            _game.BuildWorld();
            var armory = _game.AllRooms.First(r => r.Name == "Armory");

            // Act
            var itemsString = armory.AllItems();

            // Assert
            StringAssert.Contains(itemsString, "sword");
        }

        [TestMethod]
        public void Room_GetAllPaths_ShouldReturnCorrectString()
        {
            // Arrange
            var start = _game.BuildWorld();

            // Act
            var pathsString = start.GetAllPaths();

            // Assert
            StringAssert.Contains(pathsString, "North");
            StringAssert.Contains(pathsString, "South");
            StringAssert.Contains(pathsString, "East");
            StringAssert.Contains(pathsString, "West");
        }

        [TestMethod]
        public void ToString_ShouldContainCommandList()
        {
            // Act
            var output = _game.ToString();

            // Assert
            StringAssert.Contains(output, "look");
            StringAssert.Contains(output, "inventory");
            StringAssert.Contains(output, "go n|e|s|w");
            StringAssert.Contains(output, "take <id>");
            StringAssert.Contains(output, "fight");
            StringAssert.Contains(output, "quit");
        }
    }
}
