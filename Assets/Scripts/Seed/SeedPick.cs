using UnityEngine;
using System;

public class SeedPick : MonoBehaviour
{
    private SeedMain _seedMain;

    public GameObject InventorySlot1;
    private SeedInventory _seedOfInventory;

    public event Action OnTextNbOfPlant;

    /// <summary>
    /// Recovers the plant that has grown and adds it to the inventory.
    /// </summary>
    public void Pick()
    {
        _seedMain = FindObjectOfType<SeedMain>().GetComponent<SeedMain>();

        _seedOfInventory = InventorySlot1.GetComponent<SeedInventory>();
        _seedOfInventory.NbOfPlant += 1;
        OnTextNbOfPlant?.Invoke();

        _seedMain.IsGrown = false;
        _seedMain.SeedPlant.Garden.IsPlant = false;
        _seedMain.SeedPlant.Garden.ActiveMenu();
        _seedMain.SeedPlant.DestroyPlant();
    }
}
