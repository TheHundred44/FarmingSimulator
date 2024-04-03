using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedInventory : MonoBehaviour
{
    public SeedScriptableObject SeedScriptableObject;
    public int NbOfSeed;

    public TMP_Text NbOfSeedText;
    [SerializeField]private SeedBusiness _seedBusiness;
    [SerializeField]private SeedPlant _seedPlant;

    public void Awake()
    {
        TextManager();
        _seedBusiness.OnTextNbOfSeed += TextManager;
        _seedPlant.OnTextNbOfSeed += TextManager;
    }

    public void TextManager()
    {
        NbOfSeedText.text = "" + NbOfSeed;
    }
}
