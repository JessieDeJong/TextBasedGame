using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    public enum FightOutcome
    {
        PlayerWon, PlayerLost, NoMonster
    }
    public enum Direction { North, South, East, West }

    public class Rooms
    {
        public static readonly List<Room> _allRooms = new List<Room>();
        public Room currentRoom { get; set; }

        public Rooms()
        {
            currentRoom = startRoom;
        }

        public FightOutcome Fight(Inventory inventory)
        {
            if (currentRoom.hasMonster)
            {
                if (inventory.isItemInList("sword"))
                {
                    Console.WriteLine("You see the giant dragon stepping towards you.");
                    Console.WriteLine("Luckily you had picked up a very sharp sword.");
                    Console.WriteLine("With one big swing you cut the big beast.");
                    Console.WriteLine("You just defeated the monster!");
                    currentRoom.hasMonster = false;
                    return FightOutcome.PlayerWon;
                }
                else
                {
                    Console.WriteLine("You see the giant dragon stepping towards you.");
                    Console.WriteLine("Ohno, you do not have any weapons to kill this monster.");
                    Console.WriteLine("The dragon eats you in just one bite.");
                    Console.WriteLine("You died, next time better find a weapon before facing the dragon.");
                    return FightOutcome.PlayerLost;
                }
            }
            else
            {
                Console.WriteLine("There is no monster for you to fight.");
                return FightOutcome.NoMonster;
            }
        }
    }
}
