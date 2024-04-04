using UnityEngine;

public class SeedMain : MonoBehaviour
{
    public SeedScriptableObject SeedScriptableObject;
    public SeedBusiness SeedBusiness;
    public SeedPlant SeedPlant;
    public SeedGrown SeedGrown;
    public SeedPick SeedPick;

    public bool IsGrown = false;

    private void Awake()
    {
        IsGrown = SeedScriptableObject.IsGrown;
        SeedPlant = FindObjectOfType<SeedPlant>().GetComponent<SeedPlant>();
        SeedPick = FindObjectOfType<SeedPick>().GetComponent<SeedPick>();
    }
}
