using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static short stationsAvailable = 5;
    public static short redVirusAvailable = 20;
    public static short blueVirusAvailable = 20;
    public static short blackVirusAvailable = 20;
    public static short yellowVirusAvailable = 20;
    public static bool isRedCured = false;
    public static bool isBlueCured = false;
    public static bool isBlackCured = false;
    public static bool isYellowCured = false;

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

        // prevPlayer.layer = LayerMask.NameToLayer("Ignore Raycast");
        prevPlayer.GetComponent<CircleCollider2D>().enabled = false;

        // Making previous player transparent
        Color tmp = prevPlayer.GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        prevPlayer.GetComponent<SpriteRenderer>().color = tmp;

        // Activate the station of the city of the previous piece
        if (prevPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station != null)
            prevPlayer.GetComponent<DragSprite>().nextCity.GetComponent<City>().station.layer = 3; // <---------------------------- Questionable! why not 0 (I don't remember)

        // No outliner
        prevPlayer.GetComponent<SpriteRenderer>().sprite = prevPlayer.GetComponent<DragSprite>().firstImage;

        nextPlayer.layer = LayerMask.NameToLayer("Default");
        nextPlayer.GetComponent<CircleCollider2D>().enabled = true;
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

        // Get's the index of the next player in the list
        int index = 0;
        foreach(GameObject p in players)
        {
            index++;
            if (GameObject.ReferenceEquals(p, currentPlayer))
                break;
        }
        // if previous player was at the end of the list then next player is at index 0
        index %= players.Count;
        GameObject nextPlayer = players[index];


        changeTurn(prevPlayer, nextPlayer);

        return nextPlayer;
    }
}
