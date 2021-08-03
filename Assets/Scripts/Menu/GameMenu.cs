using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
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
            if (stopGamePanel.activeSelf)
            {
                gameManager.StartGame();
                stopGamePanel.SetActive(false);
            }
            else
            {
                gameManager.StopGame();
                stopGamePanel.SetActive(true);
            }
        }
    }
    public void ShowWinGamePanel()
    {
        winGameText.text = string.Format(Constants.LEVEL_COMPLATED_TEXT, activeSceneIndex);
        PlayerPrefs.SetInt(Constants.LEVEL_SAVE_NAME, activeSceneIndex + 1);
        winGamePanel.SetActive(true);
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
        gameManager.StartGame();
        stopGamePanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
