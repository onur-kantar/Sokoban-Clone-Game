using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject gameMenuPanel;
    [SerializeField] GameObject winGamePanel;
    [SerializeField] TMP_Text winGameText;
    [SerializeField] GameObject stopGamePanel;
    GameManager gameManager;
    int activeSceneIndex;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(Constants.LEVEL_SAVE_NAME, activeSceneIndex);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !winGamePanel.activeSelf)
        {
            ToggleMenu(stopGamePanel);
        }
    }
    public void ToggleMenu(GameObject subMenu)
    {
        bool activeToggle = gameMenuPanel.activeSelf;
        gameManager.ToggleGame(activeToggle);
        gameMenuPanel.SetActive(!activeToggle);
        subMenu.SetActive(!activeToggle);
    }
    public void ShowWinGamePanel()
    {
        winGameText.text = string.Format(Constants.LEVEL_COMPLATED_TEXT, activeSceneIndex);
        PlayerPrefs.SetInt(Constants.LEVEL_SAVE_NAME, activeSceneIndex + 1);
        ToggleMenu(winGamePanel);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(activeSceneIndex + 1);
    }
    public void Replay()
    {
        SceneManager.LoadScene(activeSceneIndex);
    }
    public void Continue()
    {
        ToggleMenu(stopGamePanel);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
