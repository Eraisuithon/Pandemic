using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private GameObject prevCity;
    [HideInInspector]
    public GameObject nextCity;
    private bool isDragged;

    private void Awake()
    {
        switch (name)
        {
            case "purple_piece":
                Board.players.Add(GameObject.Find("purple_piece"));
                break;
            case "orange_card":
                Board.players.Add(GameObject.Find("orange_piece"));
                break;
            case "white_piece":
                Board.players.Add(GameObject.Find("white_piece"));
                break;
            case "grey_piece":
                Board.players.Add(GameObject.Find("grey_piece"));
                break;
            case "green_piece":
                Board.players.Add(GameObject.Find("green_piece"));
                break;
            case "blue_piece":
                Board.players.Add(GameObject.Find("blue_piece"));
                break;
            case "darkGreen_piece":
                Board.players.Add(GameObject.Find("darkGreen_piece"));
                break;
        }
        Board.chooseFirstPlayer();
        Board.deactivateOthers();
    }
    private void Start()
    {
        isDragged = false;

        GameObject Atlanta = GameObject.Find("Blue_Atlanta");
        Atlanta.GetComponent<City>().pieces.Add(gameObject);
        Atlanta.GetComponent<City>().place();

        prevCity = nextCity = Atlanta;
    }

    public void OnMouseDown()
    {
        isDragged = true;
    }

    public void OnMouseUp()
    {
        isDragged = false;
        if (GetComponent<Piece>().inACity &&
            (GetComponent<Piece>().neighboors[GetComponent<Piece>().prevCity].Contains(nextCity.name)
            || prevCity.GetComponent<City>().hasStation && nextCity.GetComponent<City>().hasStation && !GameObject.ReferenceEquals(prevCity, nextCity)))
        {
            // Player made a move so we count it
            GetComponent<Piece>().numOfMoves++;

            // Centralises the piece in the city
            transform.position = nextCity.transform.position;


            // Each city has a list with the pieces in it
            int c = prevCity.GetComponent<City>().pieces.Count;
            prevCity.GetComponent<City>().pieces.Remove(gameObject);
            prevCity.GetComponent<City>().place();
            nextCity.GetComponent<City>().pieces.Add(gameObject);
            nextCity.GetComponent<City>().place();

            // Updates current city and position at Piece script
            GetComponent<Piece>().prevCity = nextCity.name;

            prevCity = nextCity;

            // if this is the 4th move then the next player will play
            if (GetComponent<Piece>().numOfMoves == 4)
            {
                Board.nextPlayer();
                GetComponent<Piece>().numOfMoves = 0;
            }
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
        if (collider.transform.parent.name != "Cities" || !isDragged) 
            return;
        nextCity = collider.gameObject;
        if (prevCity == null)
            prevCity = nextCity;
        GetComponent<Piece>().inACity = true;
    }



    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name != nextCity.name || !isDragged) return;
        GetComponent<Piece>().inACity = false;
    }

    private void Update()
    {
        if (!isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
