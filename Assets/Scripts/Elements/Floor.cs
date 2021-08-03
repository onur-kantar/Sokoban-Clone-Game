using UnityEngine;

public class Floor : Element
{
    public override bool Interaction(GameObject other, Vector2 direction)
    {
        return other.GetComponent<Movement>().Move(direction);
    }
}
