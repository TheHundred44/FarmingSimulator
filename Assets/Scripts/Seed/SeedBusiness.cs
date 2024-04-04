using UnityEngine;
using System;

public class SeedBusiness : MonoBehaviour
{
    [SerializeField]
    private SeedScriptableObject _seed;

    private MonneyManager _monneyManager;

    public event Action OnPrice;

    public event Action OnTextNbOfSeed;

    public event Action OnTextNbOfPlant;

    public GameObject InventorySlot1;
    private SeedInventory _seedOfInventory;

    private void Start()
    {
        _monneyManager = FindObjectOfType<MonneyManager>();
        _monneyManager.SeedBusiness = this.GetComponent<SeedBusiness>();
    }

    /// <summary>
    /// Allows you to buy a seed, put it in your inventory and cash it in.
    /// </summary>
    public void Buy()
    {
        _monneyManager.SeedBusiness = this.GetComponent<SeedBusiness>();
        _monneyManager.Monney -= _seed.PriceToBuy;

        if (_monneyManager.Monney <= 0)
        {
            _monneyManager.Monney = 0;
            Debug.Log("Pas assez d'argent");
        }
        else
        {
            _seedOfInventory = InventorySlot1.GetComponent<SeedInventory>();
            _seedOfInventory.SeedScriptableObject = _seed;
            _seedOfInventory.NbOfSeed += 1;
        }

        OnPrice?.Invoke();
        OnTextNbOfSeed?.Invoke();
    }

    /// <summary>
    /// Allows you to sell a plant, remove it from inventory and earn money.
    /// </summary>
    public void Sell()
    {
        if (_seedOfInventory.NbOfPlant > 0)
        {
            _monneyManager.Monney += _seed.PriceToSell;
            OnPrice?.Invoke();
            _seedOfInventory.NbOfPlant--;
            OnTextNbOfPlant?.Invoke();
        }
        else
        {
            Debug.Log("Vous n'avez pas de plantes à vendre");
        }
    }
}
