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
        if (GetComponent<Piece>().inACity && GetComponent<Piece>().numOfMoves < 4 &&
            ((GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(nextCity.name) || GetComponent<Piece>().prevCity == nextCity.name))
            || (prevCity.GetComponent<City>().hasStation && nextCity.GetComponent<City>().hasStation))
        {
            // Player made a move so we count it
            GetComponent<Piece>().numOfMoves++;

            // Centralises the piece in the city
            transform.position = nextCity.transform.position;

            // Updates current city and position at Piece script
            GetComponent<Piece>().prevCity = nextCity.name;
            GetComponent<Piece>().position = transform.position;

            prevCity = nextCity;
        }
        else
        {
            // goes to the position it was lastly at
            transform.position = GetComponent<Piece>().position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent.name == "ResearchStations")
            collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        if (collider.transform.parent.name != "Cities") 
            return;
        nextCity = collider.gameObject;
        if (prevCity == null)
            prevCity = nextCity;
        GetComponent<Piece>().inACity = true;
    }



    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.parent.name == "ResearchStations")
            collider.gameObject.layer = LayerMask.NameToLayer("Default");

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
