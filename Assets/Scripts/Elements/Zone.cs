using UnityEngine;

public class Zone : Element
{
    [SerializeField] ColorEnum color;
    [SerializeField] GameObject CollectPS;
    GameManager gameManager;
    private void Start()
    {
        gameManager = gridGenerator.gameManager;
        gameManager.IncreaseZoneCount();
    }
    public override bool Interaction(GameObject other, Vector2 direction)
    {
        if (other.GetComponent<Movement>().Move(direction))
        {
            Cube cube = other.GetComponent<Cube>();
            if (cube != null)
            {
                if (cube.color == color)
                {
                    other.GetComponent<Movement>().enabled = false;
                    cube.enabled = false;
                    Instantiate(CollectPS, transform.position, CollectPS.transform.rotation);
                    gameManager.DecreaseZoneCount();
                }
            }
            return true;
        }
        return false;
    }
}
