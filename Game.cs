using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    public class Game
    {
		private bool isGameRunning;

		public bool IsGameRunning
		{
			get { return isGameRunning; }
			set { isGameRunning = false; }
		}

        public Game()
        {
            IsGameRunning = true;
        }

        public void GameSetUp()
        {

        }

        public override string? ToString()
        {
            return @"This is a list of all the commando's:
            - look : shows you the players inventory, the current room you are in, 
              all the items available in the current room, and all the paths you can take
            - inventory : shows you only the players inventory
            - go n|e|s|w : will move the player to that direction if possible
            - take <id> : takes an item from the current room and puts it in the players inventory
            - quit : stops the game";
        }
    }
}
