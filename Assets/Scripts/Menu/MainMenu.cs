using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt(Constants.LEVEL_SAVE_NAME, 1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(Constants.LEVEL_SAVE_NAME));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
