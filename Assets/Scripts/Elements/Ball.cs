using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Element, ICanInteract
{
    Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    public bool Interaction(GameObject other)
    {
        Vector2 direction = currentPosition - other.GetComponent<Element>().currentPosition;
        if (movement.hasFallen || movement.SetDirection(direction))
        {
            return other.GetComponent<Movement>().Move(direction);
        }
        return false;
    }
}
