using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Virus : MonoBehaviour, IPointerDownHandler
{
    private void OnMouseDown()
    {
        Debug.Log("To Cure");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;

        bool areAvailable = false;
        if (name == "RedVirus" && Board.redVirusAvailable > 0 ||
            name == "BlueVirus" && Board.blueVirusAvailable > 0 ||
            name == "BlackVirus" && Board.blackVirusAvailable > 0 ||
            name == "YellowVirus" && Board.yellowVirusAvailable > 0)
        {
            areAvailable = true;
        }
        if (!areAvailable) return;
        if (name == "RedVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter == 3 ||
            name == "BlueVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter == 3 ||
            name == "BlackVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter == 3 ||
            name == "YellowVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter == 3) return;

        if (name == "RedVirus")
        {
            Board.redVirusAvailable--;
            Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter++;
        }
        else if (name == "BlueVirus")
        {
            Board.blueVirusAvailable--;
            Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter++;
        }
        else if (name == "BlackVirus")
        {
            Board.blackVirusAvailable--;
            Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter++;
        }
        else if (name == "YellowVirus")
        {
            Board.yellowVirusAvailable--;
            Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter++;
        }

        // This counts as a player move
        Board.currentPlayer.GetComponent<Piece>().numOfMoves++;
        // if this is the 4th move then the next player will play
        if (Board.currentPlayer.GetComponent<Piece>().numOfMoves == 4)
        {
            Board.currentPlayer.GetComponent<Piece>().numOfMoves = 0;
            Board.nextPlayer();
        }
    }
}
