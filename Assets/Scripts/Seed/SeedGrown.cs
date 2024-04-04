using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class SeedGrown : MonoBehaviour
{
    private SeedMain _seedMain;
    private float _timeOfGrown;

    [SerializeField]
    private TMP_Text _remainingTimeText;
    private float _remainingTime;

    private int minutes;
    private int seconds;

    private void Awake()
    {
        _seedMain = GetComponent<SeedMain>();
        _timeOfGrown = _seedMain.SeedScriptableObject.TimeOfGrown;
        _remainingTime = _timeOfGrown;
    }

    /// <summary>
    /// Allows the seed to grow into a plant, while showing the player a timer so he knows how much time is left to grow.
    /// </summary>
    public async void Grown()
    {
        _remainingTime = _timeOfGrown;
        _remainingTimeText = GameObject.Find("TextTimeRemaining").GetComponent<TMP_Text>();

        for (float i = 0; i < _timeOfGrown; i += Time.deltaTime)
        {
            minutes = (int)(_remainingTime / 60);
            seconds = (int)(_remainingTime % 60);
            _remainingTime -= Time.deltaTime;
            _remainingTimeText.text = " " + minutes.ToString("00") + " : " + seconds.ToString("00");
            await Task.Delay(1);
        }

        _seedMain.IsGrown = true;
        _seedMain.SeedPlant.Garden.ActiveMenu();
    }
}
