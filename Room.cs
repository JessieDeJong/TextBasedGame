using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDeadly { get; set; }
        public bool hasMonster { get; set; }
        public bool isLocked { get; set; }
        public List<Item> itemList { get; set; } = new List<Item>();
        public Dictionary<Direction, Room> Paths { get; } = new();

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void ConnectPaths(Room otherRoom, Direction direction)
        {
            Paths[direction] = otherRoom;
        }

        public bool Take(Inventory inventory, Item item)
        {
            if (item != null)
            {
                itemList.Remove(item);
                inventory.AddItem(item);
                return true;
            }
            return false;
        }

        public Item checkItemInList (string itemId)
        {
            foreach (var item in itemList)
            {
                if (item.Id == itemId) return item;
            }
            return null;
        }

        public bool isItemInList(string itemId)
        {
            foreach (var item in itemList)
            {
                if (item.Id == itemId) return true;
            }
            return false;
        }

        public string AllItems()
        {
            string returnString = "All the items in this room are: ";

            if (itemList.Count == 0)
            {
                returnString += "there are no items available in this room";
            }

            for (int i = 0; i < itemList.Count; i++)
            {
                if (i == itemList.Count - 1)
                {
                    returnString += $"{itemList[i].Id}.";
                }
                else
                {
                    returnString += $", {itemList[i].Id}";
                }
            }
            return returnString;
        }

        public string getAllPaths()
        {
            if (Paths.Count == 0)
            {
                return "There are no available paths";
            }
            else
            {
                string returnString = $"These are the available directions to go to from {Name}";
                foreach (var path in Paths)
                {
                    returnString += path.Key.ToString() + ", ";
                }
                return returnString.Remove(Paths.Count - 2);
            }
        }

        public override string? ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
