using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUIHandler : MonoBehaviour
{
    public void LoadFiniteMode()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadInfiniteMode()
    {
        Debug.Log("This feature coming soon!");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
