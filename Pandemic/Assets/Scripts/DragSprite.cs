using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private GameObject prevCity;
    private GameObject nextCity;
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
            ((GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(nextCity.name) || GetComponent<Piece>().prevCity == nextCity.name))
            || (prevCity.GetComponent<City>().hasStation && nextCity.GetComponent<City>().hasStation))
        {
            // Centralises the piece in the city
            GetComponent<RectTransform>().position = nextCity.transform.position;

            // Updates current city and position at Piece script
            GetComponent<Piece>().prevCity = nextCity.name;
            GetComponent<Piece>().position = transform.position;

            prevCity = nextCity;
        }
        else
        {
            // goes to the position it was lastly at
            transform.position = GetComponent<Piece>().position;
            Debug.Log("-------------");
            Debug.Log(GetComponent<Piece>().prevCity); //Atlanta
            Debug.Log(nextCity); // Chicago
            Debug.Log(GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(nextCity.name)); // true
            Debug.Log(prevCity.GetComponent<City>().hasStation); // true
            Debug.Log(GetComponent<Piece>().inACity);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Just Entered:");
        Debug.Log(collider); 
        string nearestCity = null;
        int nearestDistSquared = 0;
        foreach (Collider2D c in collider.gameObject.GetComponents<Collider2D>())
            Debug.Log(c);
        if (collider.transform.parent.name != "Cities") return;
        nextCity = collider.gameObject;
        if (prevCity == null)
        {
            prevCity = nextCity;
        }
        GetComponent<Piece>().inACity = true;
    }



    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Just Exited:");
        Debug.Log(collider);
        if (collider.name != nextCity.name) return;
        GetComponent<Piece>().inACity = false;
    }

    private void Update()
    {
        if (!isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
