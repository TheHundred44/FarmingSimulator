using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonneyManager : MonoBehaviour
{
    private static MonneyManager _instance;

    public static MonneyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("MonneyManager");
                _instance = go.AddComponent<MonneyManager>();
            }

            return _instance;
        }
    }

    public float Monney = 200;

    [SerializeField]
    private TMP_Text _textMonney;

    public SeedBusiness _seedBusiness;

    private void Awake()
    {
        RefreshMoney();
        _seedBusiness.OnPrice += RefreshMoney;
    }

    public void RefreshMoney()
    {
        _textMonney.text = "" + Monney;
    }
}
