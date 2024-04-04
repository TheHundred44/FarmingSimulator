using TMPro;
using UnityEngine;

public class SeedInventory : MonoBehaviour
{
    public SeedScriptableObject SeedScriptableObject;
    public int NbOfSeed;
    public int NbOfPlant;

    [SerializeField] private TMP_Text NbOfSeedText;
    [SerializeField] private TMP_Text NbOfPlantText;

    [SerializeField]private SeedBusiness _seedBusiness;
    [SerializeField]private SeedPlant _seedPlant;
    [SerializeField]private SeedPick _seedPick;

    public void Awake()
    {
        TextManager();

        _seedBusiness.OnTextNbOfSeed += TextManager;
        _seedBusiness.OnTextNbOfPlant += TextManager;
        _seedPlant.OnTextNbOfSeed += TextManager;
        _seedPick.OnTextNbOfPlant += TextManager;
    }

    /// <summary>
    /// Updates seed and plant number texts.
    /// </summary>
    public void TextManager()
    {
        NbOfSeedText.text = " " + NbOfSeed;
        NbOfPlantText.text = " " + NbOfPlant;
    }
}
