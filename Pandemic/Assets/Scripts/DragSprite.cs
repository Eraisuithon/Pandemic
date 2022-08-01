using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private GameObject city;
    private bool isDragged;

    private void Start()
    {
        isDragged = false;
    }

    public void OnMouseDown()
    {
        isDragged = true;
    }

    public void OnMouseUp()
    {
        isDragged = false;
        if (GetComponent<Piece>().inACity && 
            (GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(city.name) || GetComponent<Piece>().prevCity==city.name
            || GetComponent<Piece>().prevCity==city.name))
        {
            // Centralises the piece in the city
            GetComponent<RectTransform>().position = city.transform.position;

            // Updates current city and position at Piece script
            GetComponent<Piece>().prevCity = city.name;
            GetComponent<Piece>().position = transform.position;
        }
        else
        {
            // goes to the position it was lastly at
            transform.position = GetComponent<Piece>().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent.name != "Cities") return;
        city = collider.gameObject;
        GetComponent<Piece>().inACity = true;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform.parent.name != "Cities") return;
        GetComponent<Piece>().inACity = true;

        if (isDragged) return;

        city = collider.gameObject;


    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.parent.name != "Cities") return;
        GetComponent<Piece>().inACity = false;
    }

    private void Update()
    {
        if (!isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
