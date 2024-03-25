using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanged : MonoBehaviour
{
    public void SceneSwitch(string _NameOfScene)
    {
        SceneManager.LoadScene(_NameOfScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
