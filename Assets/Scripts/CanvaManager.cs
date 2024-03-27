using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    public void EtatCanva(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
