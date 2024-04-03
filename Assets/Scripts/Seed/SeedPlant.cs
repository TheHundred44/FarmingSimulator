using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeedPlant : MonoBehaviour
{
    [SerializeField]private SeedInventory _inventory;

    public event Action OnTextNbOfSeed;

    public void Plant()
    {
        _inventory.NbOfSeed -= 1;
        OnTextNbOfSeed?.Invoke();
    }
}
