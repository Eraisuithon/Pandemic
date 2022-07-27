using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private GameObject city;

    public void OnMouseDown()
    {
        GetComponent<Piece>().isDragged = true;
    }

    public void OnMouseUp()
    {
        GetComponent<Piece>().isDragged = false;
        if (GetComponent<Piece>().inACity && 
            (GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(city.name) || GetComponent<Piece>().prevCity==city.name
            || GetComponent<Piece>().prevCity==city.name))
        {
            GetComponent<RectTransform>().position = city.transform.position;
            GetComponent<Piece>().prevCity = city.name;
            GetComponent<Piece>().position = transform.position;
        }
        else
        {

            transform.position = GetComponent<Piece>().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        city = collider.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        GetComponent<Piece>().inACity = true;

        if (GetComponent<Piece>().isDragged) return;

        city = collider.gameObject;
        if (GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(collider.name))
        {
            GetComponent<RectTransform>().position = collider.transform.position;
            GetComponent<Piece>().prevCity = collider.name;
            GetComponent<Piece>().position = collider.transform.position;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GetComponent<Piece>().inACity = false;
    }

    private void Update()
    {
        if (!GetComponent<Piece>().isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
