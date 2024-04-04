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

    public SeedBusiness SeedBusiness;

    private void Awake()
    {
        RefreshMoney();
        SeedBusiness.OnPrice += RefreshMoney;
    }

    /// <summary>
    /// Update the text of the game monney.
    /// </summary>
    private void RefreshMoney()
    {
        _textMonney.text = " " + Monney;
    }
}
