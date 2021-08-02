using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : Element, ICanInteract
{
    [SerializeField] ColorEnum color;
    GameManager gameManager;
    private void Start()
    {
        gameManager = gridGenerator.gameManager;
        gameManager.IncreaseZoneCount();
    }
    public bool Interaction(GameObject other)
    {
        Vector2 direction = currentPosition - other.GetComponent<Element>().currentPosition;
        if (other.GetComponent<Movement>().Move(direction))
        {
            Cube cube = other.GetComponent<Cube>();
            if (cube != null)
            {
                if (cube.color == color)
                {
                    other.GetComponent<Movement>().enabled = false;
                    cube.enabled = false;
                    gameManager.DecreaseZoneCount();
                }
            }
            return true;
        }
        return false;
    }
}
