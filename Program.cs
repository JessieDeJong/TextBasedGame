namespace TextBasedAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
            Inventory playerInventory = new Inventory();
            Console.WriteLine("Welcome to our text based game!");
            Console.WriteLine("I will first show you the commando's then we will start your adventure...");
            Console.WriteLine(newGame);
            Rooms gameRooms = new Rooms();

            while (newGame.IsGameRunning)
            {
                string fullUserInput = Console.ReadLine().ToLower();
                string shortUserInput = fullUserInput.Split(" ")[0];

                switch (shortUserInput)
                {
                    case "help":
                        Console.WriteLine(newGame);
                        break;

                    case "look":
                        Console.WriteLine(playerInventory);
                        Console.WriteLine($"You are now in the {gameRooms.currentRoom}");
                        Console.WriteLine(gameRooms.currentRoom.AllItems());
                        Console.WriteLine(gameRooms.currentRoom.getAllPaths());
                        break;

                    case "inventory":
                        Console.WriteLine(playerInventory);
                        break;

                    case "go":
                        string direction = fullUserInput[1].ToString();
                        break;

                    case "take":
                        string itemId = fullUserInput[1].ToString();
                        Room room = gameRooms.currentRoom;
                        Item item = room.checkItemInList(itemId);

                        if (item != null)
                        {

                            room.Take(playerInventory, item);
                            playerInventory.AddItem(item);
                            Console.WriteLine($"You just took {item.Id}: {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine("This item is not available in this room");
                        }
                        break;

                    case "fight":
                        break;

                    default:
                        break;

                }

            }
            //inventory.AddItem(new Item { Id = "Magic Wand", Description = "An old wizard wand made of wood with a gem on top that glows a soft purple light." });
            //Console.WriteLine(inventory.isItemInList("Magic Wand"));
            //Console.WriteLine(inventory);

        }
    }
}
