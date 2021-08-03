using UnityEngine;

public class GameManager : MonoBehaviour
{
    int zoneCount;
    GameMenu gameMenu;
    private void Start()
    {
        gameMenu = GetComponent<GameMenu>();
    }
    public void IncreaseZoneCount()
    {
        zoneCount++;
    }
    public void DecreaseZoneCount()
    {
        zoneCount--;
        if (zoneCount == 0)
        {
            Win();
        }
    }
    void Win()
    {
        gameMenu.ShowWinGamePanel();
    }
    public void ToggleGame(bool begin)
    {
        Element[] hingeJoints = GetComponentsInChildren<Element>();
        foreach (Element joint in hingeJoints)
            joint.enabled = begin;
    }

}
