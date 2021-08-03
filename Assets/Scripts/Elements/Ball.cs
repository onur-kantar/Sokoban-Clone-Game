using UnityEngine;

public class Ball : Element
{
    Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    public override bool Interaction(GameObject other, Vector2 direction)
    {
        return (movement.hasFallen || movement.SetDirection(direction)) && other.GetComponent<Movement>().Move(direction);
    }
}
