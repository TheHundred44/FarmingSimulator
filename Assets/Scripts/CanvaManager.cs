using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    public void EtatCanva(GameObject _gameObject)
    {
        if (_gameObject.activeSelf)
        {
            _gameObject.SetActive(false);
        }
        else
        {
            _gameObject.SetActive(true);
        }
    }
}
