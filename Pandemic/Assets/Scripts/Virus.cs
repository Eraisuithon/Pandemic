using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Virus : MonoBehaviour, IPointerDownHandler
{
    private void OnMouseDown()
    {
        // Checking which color was the clicked virus and wether there where any on that city
        // for every color we check wether the virus has been cured
        if (name == "RedVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter > 0)
        {
            if (Board.isRedCured)
            {
                Board.redVirusAvailable += Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter = 0;
                // Check if eradicated
                if (Board.redVirusAvailable == 20)
                    Board.isRedEradicated = true;
            }
            else
            {
                Board.redVirusAvailable++;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().RedCounter--;
            }
        }
        else if (name == "BlueVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter > 0)
        {
            if (Board.isBlueCured)
            {
                Board.blueVirusAvailable += Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter = 0;
                // Check if eradicated
                if (Board.blueVirusAvailable == 20)
                    Board.isBlueEradicated = true;
            }
            else
            {
                Board.blueVirusAvailable++;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlueCounter--;
            }
        }
        else if (name == "BlackVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter > 0)
        {
            if (Board.isBlackCured)
            {
                Board.blackVirusAvailable += Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter = 0;
                // Check if eradicated
                if (Board.blackVirusAvailable == 20)
                    Board.isBlackEradicated = true;
            }
            else
            {
                Board.blackVirusAvailable++;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().BlackCounter--;
            }
        }
        else if (name == "YellowVirus" && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter > 0) 
        {
            if (Board.isYellowCured)
            {
                Board.yellowVirusAvailable += Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter = 0;
                // Check if eradicated
                if (Board.yellowVirusAvailable == 20)
                    Board.isYellowEradicated = true;
            }
            else
            {
                Board.yellowVirusAvailable++;
                Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().YellowCounter--;
            }
        }
        else
        {
            // if we got here then the player didn't play and hence we shouldn't count it as a move
            return;
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
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && Board.currentPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().hasStation)
        {
            // Checking to see if I should count this as a move
            bool played = true;
            if (name == "RedVirus" && !Board.isRedCured)
            {
                Board.isRedCured = true;
                if (Board.redVirusAvailable == 20)
                    Board.isRedEradicated = true;
            }
            else if (name == "BlueVirus" && !Board.isBlueCured)
            {
                Board.isBlueCured = true;
                if (Board.blueVirusAvailable == 20)
                    Board.isBlueEradicated = true;
            }
            else if (name == "BlackVirus" && !Board.isBlackCured)
            {
                Board.isBlackCured = true;
                if (Board.blackVirusAvailable == 20)
                    Board.isBlackEradicated = true;
            }
            else if (name == "YellowVirus" && !Board.isYellowCured)
            {
                Board.isYellowCured = true;
                if (Board.yellowVirusAvailable == 20)
                    Board.isYellowEradicated = true;
            }
            else
            {
                played = false;
            }
            
            if (played)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.75f);
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
        if (eventData.button != PointerEventData.InputButton.Middle) return;
        
        // if the color pressed is eradicated then we do nothing!
        if (name == "RedVirus" && Board.isRedEradicated ||
            name == "BlueVirus" && Board.isBlueEradicated ||
            name == "BlackVirus" && Board.isBlackEradicated ||
            name == "YellowVirus" && Board.isYellowEradicated) return;

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

    }
}
