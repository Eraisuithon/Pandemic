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

    public static void deactivateOthers()
    {
        foreach(GameObject p in players)
        {
            if (GameObject.ReferenceEquals(p, currentPlayer))
            {
                p.layer = LayerMask.NameToLayer("Default");
            }
            else
            {
                p.layer = LayerMask.NameToLayer("Ignore Raycast");

                // Make pieces that aren't playing transparent
                Color tmp = p.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.6f;
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
        tmp.a = 0.6f;
        prevPlayer.GetComponent<SpriteRenderer>().color = tmp;

        nextPlayer.layer = LayerMask.NameToLayer("Default");
        // Making new player not transparent
        tmp = nextPlayer.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        nextPlayer.GetComponent<SpriteRenderer>().color = tmp;

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
