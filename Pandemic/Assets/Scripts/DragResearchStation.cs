using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragResearchStation : MonoBehaviour
{

    private GameObject city;
    private bool isDragged;

    private void Start()
    {
        isDragged = false;
    }

    public void OnMouseDown()
    {
        if (GetComponent<Station>().didMove) return;
        isDragged = true;
    }

    public void OnMouseUp()
    {
        isDragged = false;
        if (GetComponent<Station>().inACity && !city.GetComponent<City>().hasStation) // to succeed the drop station must be in a city
        {
            // city now has station
            city.GetComponent<City>().hasStation = true;
            // Centralises the station in the city
            transform.position = city.transform.position;

            // Changes prev position in Station script
            GetComponent<Station>().position = transform.position;

            GetComponent<Station>().didMove = true;
        }
        else
        {
            // goes to the position it was lastly at
            transform.position = GetComponent<Station>().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent.name != "Cities") return;
        city = collider.gameObject;
        GetComponent<Station>().inACity = true;
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name != city.name) return;
        GetComponent<Station>().inACity = false;
    }

    private void Update()
    {
        if (!isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }

}
