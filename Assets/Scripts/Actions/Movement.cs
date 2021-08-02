using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    [HideInInspector] public bool hasFallen;
    Element element;
    [SerializeField] GameObject limitTextGO;
    [SerializeField] int limitCount;
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
            ICanInteract canInteract = element.gridGenerator.gridArray[nextX, nextY].goList[0].GetComponent<ICanInteract>();
            return canInteract != null ? canInteract.Interaction(gameObject) : false;
        }
        return false;
    }
    public bool Move(Vector2 direction)//direkt gidilecek yerin konumunu ver
    {
        if (limitTextGO)//ifleri düzenle
        {
            if (!(limitCount > 0))
            {
                return false;
            }
        }
        if (enabled)
        {
            int currentX = (int)(element.currentPosition).x;
            int currentY = (int)(element.currentPosition).y;
            int nextX = (int)(currentX + direction.x);
            int nextY = (int)(currentY + direction.y);

            element.gridGenerator.gridArray[nextX, nextY].goList.Insert(0, gameObject);
            element.gridGenerator.gridArray[currentX, currentY].goList.Remove(gameObject);

            transform.localPosition += new Vector3(direction.x * 2, direction.y * 2, 0);
            element.currentPosition = new Vector2(nextX, nextY);
            if (limitTextGO)
            {
                limitCount--;
                limitText.text = limitCount.ToString();
                if (!(limitCount > 0))
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
        transform.localPosition += Vector3.forward * 2;
        enabled = false;
        hasFallen = true;
        //enabled = false;
        //gameManager.Lose();
    }
}
