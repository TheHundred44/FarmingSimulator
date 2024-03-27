using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanged : MonoBehaviour
{
    public void SceneSwitch(string NameOfScene)
    {
        SceneManager.LoadScene(NameOfScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
