namespace TextBasedAdventure
{
    public class Game
    {
        public bool IsGameRunning { get; set; } = true;


        // readonly list of all rooms in the game
        public IReadOnlyList<Room> AllRooms => _allRooms;
        private readonly List<Room> _allRooms = new();


        public Room BuildWorld()
        {
            var start = new Room("Entrance Hall", "A dimly lit stone hall with torches on the walls.");
            var exit = new Room("Corridor", "A narrow corridor leading deeper into the dungeon.") { IsLocked = true };
            var armory = new Room("Armory", "Racks of old weapons and armor. There is a sword on a table.");
            var lair = new Room("Dragon Lair", "A huge cavern with the stench of sulfur. A massive dragon sleeps here.") { HasMonster = true };
            var pit = new Room("Bottomless Pit", "You fell into a pit of spikes.") { IsDeadly = true };
            var storage = new Room("Storage Closet", "A dusty storage closet. Something glints in the corner.");


            _allRooms.AddRange(new[] { start, exit, armory, lair, pit, storage });


            armory.ItemList.Add(new Item { Id = "sword", Description = "A sharp steel sword." });
            storage.ItemList.Add(new Item { Id = "key", Description = "A small iron key. It looks like it could open a simple lock." });

            start.ConnectPaths(exit, Direction.North);
            exit.ConnectPaths(start, Direction.South);

            start.ConnectPaths(armory, Direction.South);
            armory.ConnectPaths(start, Direction.North);

            armory.ConnectPaths(lair, Direction.South);
            lair.ConnectPaths(armory, Direction.North);

            start.ConnectPaths(pit, Direction.West);
            pit.ConnectPaths(start, Direction.East);

            start.ConnectPaths(storage, Direction.East);
            storage.ConnectPaths(start, Direction.West);

            return start;
        }


        public override string ToString()
        {
            return @"┌────────────────────────────────────────────────────────────────────────────────┐
│                              AVAILABLE COMMANDS                                │
├──────────────┬─────────────────────────────────────────────────────────────────┤
│ look         │ Shows you the players inventory, the current room you are in,   │
│              │ all the items available in the current room, and all the paths  │
│              │ you can take                                                    │
│ inventory    │ Shows you only the players inventory                            │
│ go n,e,s,w   │ Will move the player to that direction if possible              │
│ take <id>    │ Takes an item from the current room and puts it in the players  │
│              │ inventory                                                       │
│ fight        │ Fight a monster if present in the room                          │
│ quit         │ Stops the game                                                  │
└──────────────┴─────────────────────────────────────────────────────────────────┘";
        }
    }
}
