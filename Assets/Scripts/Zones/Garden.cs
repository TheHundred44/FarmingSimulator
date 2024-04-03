using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : ActionZone
{
    public bool IsPlant;

    [SerializeField]
    private GameObject _plantMenu;
    [SerializeField]
    private GameObject _observationMenu;
    [SerializeField]
    private GameObject _harvestMenu;

    private SeedMain _seedMain;

    public void ActiveMenu()
    {
        if (IsPlant)
        {
            _observationMenu.SetActive(true);
        }
        else
        {
            _plantMenu.SetActive(true);
        }

        if(_seedMain!= null)
        {
            if (_seedMain.IsGrown)
            {
                _harvestMenu.SetActive(true);
            }
        }
        
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        _observationMenu.SetActive(false);
        _plantMenu.SetActive(false);
        _harvestMenu.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        ActiveMenu();
    }
}
