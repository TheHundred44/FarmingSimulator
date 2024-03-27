using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Create Seed")]
public class SeedScriptableObject : ScriptableObject
{
    public string Name;
    public float TimeOfGrown;
    public float PriceToBuy;
    public float PriceToSell;
    public Sprite Sprite;
    public GameObject Prefab;
    public bool IsGrown;
}
