using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Element, ICanInteract
{
    public bool Interaction(GameObject other)
    {
        Vector2 direction = currentPosition - other.GetComponent<Element>().currentPosition;
        if (other.GetComponent<Movement>().Move(direction))
        {
            other.GetComponent<Movement>().Fall();
            return true;
        }
        return false;
    }
}
