namespace TextBasedAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
            Rooms roomsHelper = new Rooms();

            Room startingRoom = newGame.BuildWorld();

            Inventory playerInventory = new Inventory();
            Player player = new Player();
            player.CurrentRoom = startingRoom;
            player.Inventory = playerInventory;

            Console.WriteLine("Welcome to our text based game!");
            Console.WriteLine("I will first show you the commando's then we will start your adventure...");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(newGame);
            Console.WriteLine("-------------------------------");

            // Toont de speler dat die in de startroom is als het spel begint.
            Console.WriteLine($"You are in: {player.CurrentRoom.Name}");
            Console.WriteLine(player.CurrentRoom.Description);
            Console.WriteLine(player.CurrentRoom.AllItems());
            Console.WriteLine(player.CurrentRoom.GetAllPaths());

            while (newGame.IsGameRunning)
            {
                string fullUserInput = Console.ReadLine().ToLower().Trim();
                if (string.IsNullOrWhiteSpace(fullUserInput)) continue;


                string[] userInputParts = fullUserInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string shortUserInput = userInputParts[0];


                switch (shortUserInput)
                {
                    case "help":
                        Console.WriteLine(newGame);
                        break;

                    case "look":
                        Console.WriteLine(playerInventory);
                        Console.WriteLine($"You are now in the {player.CurrentRoom.Name}");
                        Console.WriteLine(player.CurrentRoom.AllItems());
                        Console.WriteLine(player.CurrentRoom.GetAllPaths());
                        break;

                    case "inventory":
                        Console.WriteLine(playerInventory);
                        break;

                    case "go":
                        if (userInputParts.Length < 2)
                        {
                            Console.WriteLine("Go where? Use: go n|e|s|w");
                            break;
                        }

                        string direction = userInputParts[1].ToLower();
                        Room nextRoom = null;

                        switch (direction)
                        {
                            case "n":
                                player.CurrentRoom.Paths.TryGetValue(Direction.North, out nextRoom);
                                break;
                            case "s":
                                player.CurrentRoom.Paths.TryGetValue(Direction.South, out nextRoom);
                                break;
                            case "e":
                                player.CurrentRoom.Paths.TryGetValue(Direction.East, out nextRoom);
                                break;
                            case "w":
                                player.CurrentRoom.Paths.TryGetValue(Direction.West, out nextRoom);
                                break;
                            default:
                                Console.WriteLine("Invalid direction. Use n, e, s, or w.");
                                break;
                        }

                        if (nextRoom != null)
                        {
                            if (nextRoom.IsLocked)
                            {
                                if (playerInventory.IsItemInList("key"))
                                {
                                    Console.WriteLine("You used the key to unlock the door!");
                                    nextRoom.IsLocked = false;
                                    var keyItem = playerInventory.CheckItemInList("key");
                                    if (keyItem != null)
                                        playerInventory.RemoveItem(keyItem);
                                }
                                else
                                {
                                    Console.WriteLine("The door is locked. You need a key to enter.");
                                    break;
                                }
                            }

                            if (nextRoom.IsDeadly)
                            {
                                player.CurrentRoom = nextRoom;
                                Console.WriteLine($"You moved to: {player.CurrentRoom.Name}");
                                Console.WriteLine(player.CurrentRoom.Description);
                                Console.WriteLine("You died, better luck next time!");
                                newGame.IsGameRunning = false;
                                break;
                            }

                            player.CurrentRoom = nextRoom;
                            Console.WriteLine($"You moved to: {player.CurrentRoom.Name}");
                            Console.WriteLine(player.CurrentRoom.Description);

                        }
                        else if (direction == "n" || direction == "s" || direction == "e" || direction == "w")
                        {
                            Console.WriteLine("You cannot go that way.");
                        }

                        break;

                    case "take":
                        if (userInputParts.Length < 2)
                        {
                            Console.WriteLine("Take what? Use: take <itemId>");
                            break;
                        }
                        string itemId = userInputParts[1];
                        Room currentRoom = player.CurrentRoom;
                        Item item = currentRoom.CheckItemInList(itemId);

                        if (item != null)
                        {
                            bool taken = currentRoom.Take(playerInventory, item);
                            if (taken)
                            {
                                Console.WriteLine($"You just took {item.Id}: {item.Description}");
                            }
                            else
                            {
                                Console.WriteLine("Could not take the item.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This item is not available in this room");
                        }
                        break;

                    case "fight":
                        var outcome = roomsHelper.Fight(playerInventory, player);
                        if (outcome == FightOutcome.PlayerLost)
                        {
                            Console.WriteLine("You died. Game over.");
                            newGame.IsGameRunning = false;
                        }
                        break;

                    case "quit":
                        newGame.IsGameRunning = false;
                        Console.WriteLine("Thanks for playing!");
                        break;

                    default:
                        Console.WriteLine("Unknown command. Type 'help' to see available commands.");
                        break;
                }

            }
        }
    }
}
