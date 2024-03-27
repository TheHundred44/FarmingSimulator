using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InventoryItem : MonoBehaviour
{
    public SeedScriptableObject seed {  get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(SeedScriptableObject data)
    {
        seed = data;
        AddToStack();

    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveToStack()
    {
        stackSize--;
    }
}
