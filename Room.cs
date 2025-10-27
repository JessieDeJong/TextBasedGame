using System.Linq;
using System.Text;
using TextBasedAdventure;

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
        if (item != null && itemList.Contains(item))
        {
            itemList.Remove(item);
            inventory.AddItem(item);
            return true;
        }
        return false;
    }


    public Item checkItemInList(string itemId) {
        foreach (var item in itemList) 
        { 
            if (item.Id == itemId) return item; 
        } return null; 
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
