using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMain : MonoBehaviour
{
    public SeedScriptableObject SeedScriptableObject;

    public SeedBusiness SeedBusiness;
    public SeedPlant SeedPlant;
    public SeedGrown SeedGrown;
    public SeedPick SeedPick;

    public bool IsGrown;

    private void Awake()
    {
        IsGrown = SeedScriptableObject.IsGrown;
    }
}
