using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    [HideInInspector] public bool hasFallen;
    [SerializeField] GameObject limitTextGO;
    [SerializeField] int limitCount;
    Element element;
    TMP_Text limitText;
    private void Start()
    {
        element = GetComponent<Element>();
        SetLimitText();
    }
    public void CreateLimit(GameObject limitTextGO, int limitCount)
    {
        this.limitCount = limitCount;
        this.limitTextGO = Instantiate(limitTextGO, transform.position, Quaternion.identity);
        this.limitTextGO.transform.SetParent(transform);
        this.limitTextGO.transform.localPosition = limitTextGO.transform.localPosition;
        SetLimitText();
    }
    void SetLimitText()
    {
        if (limitTextGO)
        {
            limitText = limitTextGO.GetComponent<TMP_Text>();
            limitText.text = limitCount.ToString();
        }
    }
    public bool SetDirection(Vector2 direction)
    {
        if (element.enabled)
        {
            int nextX = (int)(element.currentPosition.x + direction.x);
            int nextY = (int)(element.currentPosition.y + direction.y);
            Element otherElement = element.gridGenerator.gridArray[nextX, nextY].goList[0].GetComponent<Element>();
            return otherElement.Interaction(gameObject, direction);
        }
        return false;
    }
    public bool Move(Vector2 position)
    {
        if (limitTextGO && limitCount < 1)
        {
            return false;
        }
        if (enabled)
        {
            int currentX = (int)(element.currentPosition).x;
            int currentY = (int)(element.currentPosition).y;
            int nextX = (int)(currentX + position.x);
            int nextY = (int)(currentY + position.y);

            element.gridGenerator.gridArray[nextX, nextY].goList.Insert(0, gameObject);
            element.gridGenerator.gridArray[currentX, currentY].goList.Remove(gameObject);

            transform.localPosition += new Vector3(position.x, position.y, 0) * Constants.ELEMENT_SIZE;
            element.currentPosition = new Vector2(nextX, nextY);
            if (limitTextGO)
            {
                limitCount--;
                limitText.text = limitCount.ToString();
                if (limitCount < 1)
                {
                    element.enabled = false;
                    enabled = false;
                }
            }
        }
        return true;
    }
    public void Fall()
    {
        transform.localPosition += Vector3.forward * Constants.ELEMENT_SIZE;
        enabled = false;
        hasFallen = true;
    }
}
