using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static short stationsAvailable = 5;

    [Header("Who is playing?")]
    public static List<GameObject> players = new List<GameObject>();

    [Header("Character Playing")]
    public static GameObject currentPlayer;

    // how much transparent should the pieces be
    private static float alpha = 0.75f;

    public static void deactivateOthers()
    {
        foreach(GameObject p in players)
        {
            if (GameObject.ReferenceEquals(p, currentPlayer))
            {
                p.layer = LayerMask.NameToLayer("Default");
                p.GetComponent<SpriteRenderer>().sprite = p.GetComponent<DragSprite>().secondImage;

            }
            else
            {
                p.layer = LayerMask.NameToLayer("Ignore Raycast");

                // Make pieces that aren't playing transparent
                Color tmp = p.GetComponent<SpriteRenderer>().color;
                tmp.a = alpha;
                p.GetComponent<SpriteRenderer>().color = tmp;
            }

        }
    }

    public static void chooseFirstPlayer()
    {
        currentPlayer = players[0];
    }

    private static void changeTurn(GameObject prevPlayer, GameObject nextPlayer)
    {
        prevPlayer.layer = LayerMask.NameToLayer("Ignore Raycast");
        // Making previous player transparent
        Color tmp = prevPlayer.GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        prevPlayer.GetComponent<SpriteRenderer>().color = tmp;

        // Activate the station of the city of the previous piece
        if(prevPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station != null)
            prevPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station.layer = LayerMask.NameToLayer("Default");
        Debug.Log(prevPlayer.GetComponent<DragSprite>().nextCity);
        if (prevPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station == null)
            Debug.Log("Nothing");

        // No outliner
        prevPlayer.GetComponent<SpriteRenderer>().sprite = prevPlayer.GetComponent<DragSprite>().firstImage;

        nextPlayer.layer = LayerMask.NameToLayer("Default");
        // Making new player not transparent
        tmp = nextPlayer.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        nextPlayer.GetComponent<SpriteRenderer>().color = tmp;

        // Deactivate the station of the city of the previous piece
        if(nextPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station != null)
            nextPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station.layer = LayerMask.NameToLayer("Ignore Raycast");

        // With outliner
        nextPlayer.GetComponent<SpriteRenderer>().sprite = nextPlayer.GetComponent<DragSprite>().secondImage;

        currentPlayer = nextPlayer;
    }
    public static GameObject nextPlayer()
    {
        GameObject prevPlayer = currentPlayer;

        int index = 0;
        foreach(GameObject p in players)
        {
            index++;
            if (GameObject.ReferenceEquals(p, currentPlayer))
                break;
        }
        index %= players.Count;
        GameObject nextPlayer = players[index];


        changeTurn(prevPlayer, nextPlayer);
        return nextPlayer;
    }
}
