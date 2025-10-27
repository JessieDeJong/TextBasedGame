namespace TextBasedAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public Room currentRoom { get; set; }
        public Inventory Inventory { get; set; }


        public Player(string name, Room room, Inventory inventory)
        {
            Name = name;
            currentRoom = room;
            Inventory = inventory;
        }

        public Player() { }

        public bool CheckForItem(string itemId)
        {
            return Inventory != null && Inventory.isItemInList(itemId);
        }
    }
}