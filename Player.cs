namespace TextBasedAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public Room CurrentRoom { get; set; }
        public Inventory Inventory { get; set; }


        public Player(string name, Room room, Inventory inventory)
        {
            Name = name;
            CurrentRoom = room;
            Inventory = inventory;
        }

        public Player() { }

        public bool CheckForItem(string itemId)
        {
            return Inventory != null && Inventory.IsItemInList(itemId);
        }
    }
}