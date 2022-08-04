using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static short stationsAvailable;
    public static bool isDispatcherPlaying;
    public static bool isMedicPlaying;
    public static bool isScientistPlaying;
    public static bool isResearcherPlaying;
    public static bool isOperationsExpertPlaying;
    public static bool isContingencyPlannerPlaying;
    public static bool isQuarantineSpecialistPlaying;

    public static GameObject dispatcher;
    public static GameObject medic;
    public static GameObject scientist;
    public static GameObject researcher;
    public static GameObject operationsExpert;
    public static GameObject contingencyPlanner;
    public static GameObject quarantineSpecialist;

    // Start is called before the first frame update
    void Start()
    {
        stationsAvailable = 5;
        dispatcher = GameObject.Find("purple_piece");
        medic = GameObject.Find("orange_piece");
        quarantineSpecialist = GameObject.Find("darkGreen_piece");
        contingencyPlanner = GameObject.Find("blue_piece");
        researcher = GameObject.Find("grey_piece");
        scientist = GameObject.Find("white_piece");
        operationsExpert = GameObject.Find("green_piece");
    }

    private static void changeTurn(GameObject prevPlayer, GameObject nextPlayer)
    {
        prevPlayer.layer = LayerMask.NameToLayer("Ignore Raycast");
        nextPlayer.layer = LayerMask.NameToLayer("Default");
    }
    public static GameObject nextPlayer(GameObject prevPlayer)
    {
        GameObject nextPlayer = prevPlayer;
        switch (prevPlayer.name)
        {
            case "purple_piece":
                if (isMedicPlaying)
                {
                    nextPlayer = medic;
                    break;
                }
                goto case "orange_card";
            case "orange_card":
                if (isScientistPlaying)
                {
                    nextPlayer = scientist;
                    break;
                }
                goto case "white_piece";
            case "white_piece":
                if (isResearcherPlaying)
                {
                    nextPlayer = researcher;
                    break;
                }
                goto case "grey_piece";
            case "grey_piece":
                if (isOperationsExpertPlaying)
                {
                    nextPlayer = operationsExpert;
                    break;
                }
                goto case "green_piece";
            case "green_piece":
                if (isContingencyPlannerPlaying)
                {
                    nextPlayer = contingencyPlanner;
                    break;
                }
                goto case "blue_piece";
            case "blue_piece":
                if (isQuarantineSpecialistPlaying)
                {
                    nextPlayer = quarantineSpecialist;
                    break;
                }
                goto case "darkGreen_piece";
            case "darkGreen_piece":
                if (isDispatcherPlaying)
                {
                    nextPlayer = dispatcher;
                    break;
                }
                goto case "purple_piece";
        }
        changeTurn(prevPlayer, nextPlayer);
        return nextPlayer;
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
