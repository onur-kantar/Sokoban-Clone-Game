using System.Collections.Generic;
using UnityEngine;
public class GridGenerator : MonoBehaviour
{
    [HideInInspector] public GameManager gameManager;

    [Header("Elements")]
    [SerializeField] List<GameObject> elements;
    [SerializeField] GameObject limitTextGO;

    [Header("Grid Information")]
    [SerializeField] int column;
    [SerializeField] int row;
    public GridCell[,] gridArray;

    [Header("Update")]
    public Elements updateElement;
    [SerializeField] Vector2 updatePosition;
    [HideInInspector] public bool hasLimit;
    [HideInInspector] public int limitCount;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        FillGridArray();
    }
    void ScaleCamera()
    {
        Camera.main.transform.position = new Vector3(column - 1, row - 1, Camera.main.transform.position.z);

        float screenRatio = Camera.main.aspect;
        float targetRatio = (float)column / (float)row;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = (float)row;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = (float)row * differenceInSize;
        }
    }
    public void FillGridArray()
    {
        gridArray = new GridCell[column, row];
        foreach (Transform child in transform)
        {
            Element element = child.GetComponent<Element>();
            int x = (int)element.currentPosition.x;
            int y = (int)element.currentPosition.y;
            if (gridArray[x, y] == null)
            {
                gridArray[x, y] = new GridCell(new List<GameObject>());
            }
            gridArray[x, y].goList.Add(child.gameObject);
        }
    }
    public void UpdateGrid()
    {
        if (gridArray == null)
        {
            FillGridArray();
        }
        DestroySpecificChildren(gridArray[((int)updatePosition.x), ((int)updatePosition.y)].goList);
        GameObject go = CreateElement(FindElement(updateElement), updatePosition);
        if (go.GetComponent<Movement>() && hasLimit)
        {
            go.GetComponent<Movement>().CreateLimit(limitTextGO, limitCount);
        }
    }
    public void ResetGrid()
    {
        ScaleCamera();
        Vector2 position;
        gridArray = new GridCell[column, row];
        DestroyAllChildren();
        for (int x = 0; x < column; x++)
        {
            for (int y = 0; y < row; y++)
            {
                position = new Vector2(x, y);
                if (y == 0 || y == row - 1 || x == 0 || x == column - 1)
                {
                    CreateElement(FindElement(Elements.Wall), position);
                }
                else
                {
                    CreateElement(FindElement(Elements.Floor), position);
                }
            }
        }
    }
    public GameObject FindElement(Elements elementName)
    {
        foreach (var element in elements)
        {
            Element elementComponent = element.GetComponent<Element>();
            if (elementComponent.ElementName == elementName)
            {
                return element;
            }
        }
        return null;
    }
    GameObject CreateElement(GameObject element, Vector2 position)
    {
        int x = (int)position.x;
        int y = (int)position.y;
        Element elementComponent = element.GetComponent<Element>();
        List<GameObject> tempList = new List<GameObject>();
        GameObject go = InstantiateElement(element, position, tempList);
        if (elementComponent.hasFloor)
        {
            InstantiateElement(FindElement(Elements.Floor), position, tempList);
        }
        gridArray[x, y] = new GridCell(tempList);
        return go;
    }
    GameObject InstantiateElement(GameObject element, Vector2 position, List<GameObject> tempList)
    {
        GameObject go = Instantiate(element, position * Constants.ELEMENT_SIZE, element.transform.rotation);
        go.transform.localPosition += element.transform.localPosition;
        go.transform.parent = transform;
        go.GetComponent<Element>().SetProperties(this, position);
        tempList.Add(go);
        return go;
    }
    void DestroyAllChildren()
    {
        GameObject [] tempArray = new GameObject[transform.childCount];
        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject child in tempArray)
        {
            DestroyImmediate(child);
        }
    }
    void DestroySpecificChildren(List<GameObject> goList)
    {
        foreach (var goListItem in goList)
        {
            DestroyImmediate(goListItem);
        }
    }
}
