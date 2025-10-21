using static TextBasedAdventure.Utility;
namespace TextBasedAdventure
{
    public enum FightOutcome { PlayerWon, PlayerLost, NoMonster }
    public enum Direction { North, South, East, West }

    public class Rooms
    {
        public FightOutcome Fight(Inventory inventory, Player player)
        {
            if (player.CurrentRoom.HasMonster)
            {
                if (inventory.HasItem("sword"))
                {
                    Console.WriteLine("You see the giant dragon stepping towards you.");
                    Console.WriteLine("Luckily you had picked up a very sharp sword.");
                    Console.WriteLine("With one big swing you cut the big beast.");
                    WriteLineColor(ConsoleColor.Red,"You just defeated the monster!");
                    player.CurrentRoom.HasMonster = false;
                    return FightOutcome.PlayerWon;
                }

                Console.WriteLine("You see the giant dragon stepping towards you.");
                Console.WriteLine("Ohno, you do not have any weapons to kill this monster.");
                Console.WriteLine("The dragon eats you in just one bite.");
                Console.WriteLine("You died, next time better find a weapon before facing the dragon.");
                return FightOutcome.PlayerLost;
            }

            Console.WriteLine("There is no monster for you to fight.");
            return FightOutcome.NoMonster;
        }
    }
}