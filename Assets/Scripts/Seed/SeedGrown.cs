using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedGrown : MonoBehaviour
{
    private SeedMain _seedMain;
    private float _timeOfGrown;

    [SerializeField]
    private TMP_Text _remainingTimeText;
    private float _remainingTime;

    private void Start()
    {
        _seedMain = GetComponent<SeedMain>();
        _timeOfGrown = _seedMain.SeedScriptableObject.TimeOfGrown;
    }

    public void Grown()
    {
        for(float i = 0; i < _timeOfGrown; i += Time.deltaTime)
        {
            _remainingTime -= Time.deltaTime;
            _remainingTimeText.text = "" + _remainingTime;
        }
        _seedMain.IsGrown = true;
    }
}
