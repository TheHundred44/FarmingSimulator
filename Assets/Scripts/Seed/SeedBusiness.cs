using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeedBusiness : MonoBehaviour
{
    [SerializeField]
    private SeedScriptableObject _seed;

    private MonneyManager _monneyManager;

    public event Action OnPrice;

    private void Start()
    {
        _monneyManager = FindObjectOfType<MonneyManager>();
        _monneyManager._seedBusiness = this.GetComponent<SeedBusiness>();
    }

    public void Buy()
    {
        _monneyManager._seedBusiness = this.GetComponent<SeedBusiness>();
        _monneyManager.Monney -= _seed.PriceToBuy;
        if(_monneyManager.Monney <= 0)
        {
            _monneyManager.Monney = 0;
            Debug.Log("Pas assez d'argent");
        }
        else
        {
            //Ajoute la seed dans l'inventaire
        }
        OnPrice?.Invoke();
        
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
