namespace TextBasedAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public Room currentRoom { get; set; }
        public static readonly List<Item> _inventory = new List<Item>();

        public Player(string name, Room room)
        {
            Name = name;
            currentRoom = room;
        }

        public bool checkForItem(string itemId)
        {
            foreach (var item in _inventory)
            {
                if (item.Id == itemId) return true;
            }
            return false;
        }
    }
}