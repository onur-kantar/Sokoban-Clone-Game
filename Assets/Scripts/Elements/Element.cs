using System;
using UnityEngine;

public class Element : MonoBehaviour
{
    public Elements ElementName;
    public bool hasFloor;
    [HideInInspector] public GridGenerator gridGenerator;
#if UNITY_EDITOR
    [ShowOnly]
#endif
    public Vector2 currentPosition;
    public void SetProperties(GridGenerator gridGenerator, Vector2 currentPosition)
    {
        this.gridGenerator = gridGenerator;
        this.currentPosition = currentPosition;
    }
    
}
public enum Elements { Floor, Wall, Ball, Hole, GreenZone, BlueZone, GreenCube, BlueCube };
public enum ColorEnum { Blue, Green };
