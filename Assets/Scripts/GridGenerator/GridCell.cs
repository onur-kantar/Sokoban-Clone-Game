using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    public List<GameObject> goList = new List<GameObject>();
    public GridCell(List<GameObject> goList)
    {
        this.goList = goList;
    }
}
