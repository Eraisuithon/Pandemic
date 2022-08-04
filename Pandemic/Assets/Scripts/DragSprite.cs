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

        switch (name)
        {
            case "purple_piece":
                Board.isDispatcherPlaying = true;
                break;
            case "orange_card":
                Board.isMedicPlaying = true;
                break;
            case "white_piece":
                Board.isScientistPlaying = true;
                break;
            case "grey_piece":
                Board.isResearcherPlaying = true;
                break;
            case "green_piece":
                Board.isOperationsExpertPlaying = true;
                break;
            case "blue_piece":
                Board.isContingencyPlannerPlaying = true;
                break;
            case "darkGreen_piece":
                Board.isQuarantineSpecialistPlaying = true;
                break;
        }
        GameObject Atlanta = GameObject.Find("Blue_Atlanta");
        Atlanta.GetComponent<City>().pieces.Add(gameObject);
        Atlanta.GetComponent<City>().place();
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
            // Player made a move so we count it
            GetComponent<Piece>().numOfMoves++;

            // Centralises the piece in the city
            transform.position = nextCity.transform.position;

            // Updates current city and position at Piece script
            GetComponent<Piece>().prevCity = nextCity.name;
            GetComponent<Piece>().position = transform.position;

            prevCity.GetComponent<City>().pieces.Remove(gameObject);
            prevCity.GetComponent<City>().place();
            nextCity.GetComponent<City>().pieces.Add(gameObject);
            nextCity.GetComponent<City>().place();

            prevCity = nextCity;

            // if this is the 4th move then the next player will play
            if (GetComponent<Piece>().numOfMoves == 4)
            {
                Board.nextPlayer(gameObject);
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
        if (collider.transform.parent.name != "Cities") 
            return;
        nextCity = collider.gameObject;
        if (prevCity == null)
            prevCity = nextCity;
        GetComponent<Piece>().inACity = true;
    }



    private void OnTriggerExit2D(Collider2D collider)
    {
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
