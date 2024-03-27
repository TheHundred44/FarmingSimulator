using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPick : MonoBehaviour
{
    public ScriptableObject scriptableObject;

    public void Pick()
    {
        
        //InventorySystem.current.Add(scriptableObject);
        Destroy(gameObject);
    }
}
