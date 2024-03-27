using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<SeedScriptableObject, InventoryItem> _dictionary;
    public List<InventoryItem> Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new List<InventoryItem>();
        _dictionary = new Dictionary<SeedScriptableObject, InventoryItem>();
    }

    public void Add(SeedScriptableObject seed)
    {
        if(_dictionary.TryGetValue(seed, out InventoryItem item))
        {
            item.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(seed);
            Inventory.Add(newItem);
            _dictionary.Add(seed, newItem);
        }
    }

    public void Remove(SeedScriptableObject seed)
    {
        if(_dictionary.TryGetValue(seed, out InventoryItem item))
        {
            item.RemoveToStack();

            if(item.stackSize == 0)
            {
                Inventory.Remove(item);
                _dictionary.Remove(seed);
            }
        }
    }

}
