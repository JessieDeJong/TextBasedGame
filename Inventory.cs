using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    public class Inventory
    {
        public static readonly List<Item> _inventory = new List<Item>();

        public Inventory()
        {
        }

        public void AddItem (Item item)
        {
            _inventory.Add(item);
        }

        public void RemoveItem (Item item) 
        {
            _inventory.Remove(item);
        }

        public Item checkItemInList(string itemId)
        {
            foreach (var item in _inventory)
            {
                if (item.Id == itemId) return item;
            }
            return null;
        }

        public bool isItemInList(string itemId)
        {
            foreach (var item in _inventory)
            {
                if (item.Id == itemId) return true;
            }
            return false;
        }

        public override string? ToString()
        {
            string returnString = "These are the item(s) in your inventory: ";
            if (_inventory.Count == 0)
            {
                returnString += "you do not have any items in your inventory right now.";
            }
            else
            {
                for (int i = 0; i < _inventory.Count; i++)
                {
                    if (i == (_inventory.Count -1))
                    {
                        returnString += _inventory[i].Id + ".";
                    }
                    else
                    {
                        returnString += _inventory[i].Id + ", ";
                    }
                }
            }
            return returnString;
        }
    }
}
