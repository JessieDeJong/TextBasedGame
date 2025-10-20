using System.Text;

namespace TextBasedAdventure
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeadly { get; set; }
        public bool HasMonster { get; set; }
        public bool IsLocked { get; set; }
        public List<Item> ItemList { get; set; } = new();
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
            if (item != null && ItemList.Contains(item))
            {
                ItemList.Remove(item);
                inventory.AddItem(item);
                return true;
            }

            return false;
        }


        public Item CheckItemInList(string itemId)
        {
            foreach (var item in ItemList)
            {
                if (item.Id == itemId) return item;
            }

            return null;
        }


        public bool IsItemInList(string itemId)
        {
            foreach (var item in ItemList)
            {
                if (item.Id == itemId) return true;
            }

            return false;
        }


        public string AllItems()
        {
            string returnString = "All the items in this room are: ";

            if (ItemList.Count == 0)
            {
                returnString += "there are no items available in this room";
            }

            for (int i = 0; i < ItemList.Count; i++)
            {
                if (i == ItemList.Count - 1)
                {
                    returnString += $"{ItemList[i].Id}.";
                }
                else
                {
                    returnString += $", {ItemList[i].Id}";
                }
            }

            return returnString;
        }


        public string GetAllPaths()
        {
            if (Paths.Count == 0)
            {
                return "There are no available paths.";
            }


            StringBuilder sb = new StringBuilder($"These are the available directions to go to from {Name}: ");
            int i = 0;
            foreach (var path in Paths)
            {
                sb.Append(path.Key.ToString());
                if (i < Paths.Count - 1) sb.Append(", ");
                i++;
            }

            sb.Append('.');
            return sb.ToString();
        }


        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}