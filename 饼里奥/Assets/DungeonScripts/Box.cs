using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Color finishColor;
    public Color originColor;

    private void Awake()
    {
        originColor = GetComponent<SpriteRenderer>().color;
        FindObjectOfType<DungeonGameManager>().totalBoxs++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxTarget"))
        {
            GetComponent<SpriteRenderer>().color = finishColor;
            FindObjectOfType<DungeonGameManager>().finishedBoxs++;
            FindObjectOfType<DungeonGameManager>().CheckBoxFinish();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxTarget"))
        {
            GetComponent<SpriteRenderer>().color = originColor;
            FindObjectOfType<DungeonGameManager>().finishedBoxs--;
        }
        
    }
}
