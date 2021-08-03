using UnityEngine;

public class Cube : Element
{
    Movement movement;
    public ColorEnum color;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    public override bool Interaction(GameObject other, Vector2 direction)
    {
        return (movement.hasFallen || movement.SetDirection(direction)) && other.GetComponent<Movement>().Move(direction);
    }
}
