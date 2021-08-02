using System.Collections;
using System.Collections.Generic;
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
        StopGame();
        gameMenu.ShowWinGamePanel();
    }
    public void Lose()
    {
    }
    public void StopGame()
    {
        Element[] hingeJoints = GetComponentsInChildren<Element>();
        foreach (Element joint in hingeJoints)
            joint.enabled = false;
    }
    public void StartGame()
    {
        Element[] hingeJoints = GetComponentsInChildren<Element>();
        foreach (Element joint in hingeJoints)
            joint.enabled = true;
    }
}
