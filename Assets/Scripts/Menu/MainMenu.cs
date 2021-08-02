using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("level", 1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
