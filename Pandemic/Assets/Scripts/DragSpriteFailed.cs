using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSpriteFailed : MonoBehaviour
{
    private GameObject piece;

    public void OnMouseDown()
    {
        piece.GetComponent<Piece>().isDragged = true;
    }

    public void OnMouseUp()
    {
        piece.GetComponent<Piece>().isDragged = false;
        if (piece.GetComponent<Piece>().inACity && piece.GetComponent<Piece>().neighboors[piece.GetComponent<Piece>().prevCity].Contains(piece.GetComponent<Piece>().lastCitySeenIn))
        {
            piece.transform.position = piece.GetComponent<Piece>().lastPositionSeenIn;
            piece.GetComponent<Piece>().prevCity = piece.GetComponent<Piece>().lastCitySeenIn;
            piece.GetComponent<Piece>().position = piece.GetComponent<Piece>().lastPositionSeenIn;
        }
        else
        {
            piece.transform.position = piece.GetComponent<Piece>().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        piece = collider.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        collider.GetComponent<Piece>().lastCitySeenIn = name;
        collider.GetComponent<Piece>().lastPositionSeenIn = transform.position;
        collider.GetComponent<Piece>().inACity = true;
        piece = collider.gameObject;
        if (piece.GetComponent<Piece>().isDragged || 
            !collider.GetComponent<Piece>().neighboors[collider.GetComponent<Piece>().prevCity].Contains(name) && collider.GetComponent<Piece>().prevCity!=name) return;
        collider.transform.position = GetComponent<Transform>().position;
        piece.GetComponent<Piece>().prevCity = name;
        piece.GetComponent<Piece>().position = transform.position;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        collider.GetComponent<Piece>().inACity = false;

    }


    private void Update()
    {
        if (piece == null) return;
        if (!piece.GetComponent<Piece>().isDragged) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - piece.transform.position;
        piece.transform.Translate(mousePosition);
    }
}
