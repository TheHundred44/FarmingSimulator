using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : ActionZone
{
    public bool IsPlant;

    public GameObject PlantMenu;
    public GameObject ObservationMenu;

    public void ActiveMenu()
    {
        if (IsPlant)
        {
            ObservationMenu.SetActive(true);
        }
        else
        {
            PlantMenu.SetActive(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        ObservationMenu.SetActive(false);
        PlantMenu.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        ActiveMenu();
    }
}
