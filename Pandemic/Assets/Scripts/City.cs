using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public int BlackCounter;
    public int YellowCounter;
    public int RedCounter;
    public int BlueCounter;
    public bool hasStation;
    // Start is called before the first frame update
    void Start()
    {
        BlackCounter = 0;
        YellowCounter = 0;
        RedCounter = 0;
        BlueCounter = 0;
        hasStation = false;
        if (name == "Blue_Atlanta")
            hasStation = true;
    }

}
