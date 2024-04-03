using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SeedBusiness : MonoBehaviour
{
    [SerializeField]
    private SeedScriptableObject _seed;

    private MonneyManager _monneyManager;

    public event Action OnPrice;
    public event Action OnTextNbOfSeed;

    public GameObject InventorySlot1;
    private Sprite SpriteSlot1;
    private SeedInventory _seedOfInventory;

    private void Start()
    {
        _monneyManager = FindObjectOfType<MonneyManager>();
        _monneyManager._seedBusiness = this.GetComponent<SeedBusiness>();
    }

    public void Buy()
    {
        _monneyManager._seedBusiness = this.GetComponent<SeedBusiness>();
        _monneyManager.Monney -= _seed.PriceToBuy;

        if (_monneyManager.Monney <= 0)
        {
            _monneyManager.Monney = 0;
            Debug.Log("Pas assez d'argent");
        }
        else
        {
            SpriteSlot1 = InventorySlot1.GetComponent<Sprite>();
            SpriteSlot1 = _seed.Sprite;
            _seedOfInventory = InventorySlot1.GetComponent<SeedInventory>();
            _seedOfInventory.SeedScriptableObject = _seed;
            _seedOfInventory.NbOfSeed += 1;
        }

        OnPrice?.Invoke();
        OnTextNbOfSeed?.Invoke();
    }

    public void Sell(float price)
    {
        //if(NbSeed>0)
        //{
        //    _monneyManager.Monney += price;
        //    OnPrice?.Invoke();
        //    Suprimme une seed de l'inventaire
        //}
        //else{
        //  Debug.Log("Pas de graine de ce type");
        //}
    }
}
