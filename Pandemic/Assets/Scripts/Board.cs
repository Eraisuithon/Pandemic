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
                p.layer = LayerMask.NameToLayer("Default");
            else
                p.layer = LayerMask.NameToLayer("Ignore Raycast");

        }
    }

    public static void chooseFirstPlayer()
    {
        currentPlayer = players[0];
    }

    private static void changeTurn(GameObject prevPlayer, GameObject nextPlayer)
    {
        prevPlayer.layer = LayerMask.NameToLayer("Ignore Raycast");
        nextPlayer.layer = LayerMask.NameToLayer("Default");

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
