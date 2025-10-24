namespace TextBasedAdventure
{
    public class Inventory
    {
        private readonly List<Item> _inventory = new();


        public void AddItem(Item item)
        {
            _inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _inventory.Remove(item);
        }

        public Item CheckItemInList(string itemId) //GetItem
        {
            foreach (var item in _inventory)
            {
                if (item.Id == itemId) return item;
            }
            return null;
        }

        public bool HasItem(string itemId)
        {
            foreach (var item in _inventory)
            {
                if (item.Id == itemId) return true;
            }
            return false;
        }

        public override string? ToString()
        {
            if (_inventory.Count == 0)
            {
                return "You do not have any items in your inventory right now.";
            }

            string[] itemIds = new string[_inventory.Count];
            for (int i = 0; i < _inventory.Count; i++)
            {
                itemIds[i] = _inventory[i].Id;
            }

            return "These are the item(s) in your inventory: " + string.Join(", ", itemIds) + ".";
        }
    }
}