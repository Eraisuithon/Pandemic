using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragResearchStation : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (GetComponent<Station>().didMove && Board.stationsAvailable!=0) return;
        if (Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().hasStation) return;
        transform.position = Board.currentPlayer.GetComponent<DragSprite>().nextCity.transform.position;

        // Every time a station is used, there is one available station less
        // If there are no stations available then we can use the stations on board
        if (Board.stationsAvailable > 0)
            Board.stationsAvailable--;

        // city now has station
        Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().hasStation = true;

        GetComponent<Station>().didMove = true;

        // This counts as a player move
        Board.currentPlayer.GetComponent<Piece>().numOfMoves++;
        // if this is the 4th move then the next player will play
        if (Board.currentPlayer.GetComponent<Piece>().numOfMoves == 4)
        {
            Board.nextPlayer();
            Board.currentPlayer.GetComponent<Piece>().numOfMoves = 0;
        }
    }
}
