using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Element, ICanInteract
{
    Movement movement;
    public ColorEnum color;

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
