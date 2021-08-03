using UnityEngine;

public class Hole : Element
{
    public override bool Interaction(GameObject other, Vector2 direction)
    {
        if (other.GetComponent<Movement>().Move(direction))
        {
            other.GetComponent<Movement>().Fall();
            return true;
        }
        return false;
    }
}
