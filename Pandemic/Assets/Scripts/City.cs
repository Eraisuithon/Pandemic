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
    public List<GameObject> pieces;
    // Start is called before the first frame update
    void Awake()
    {
        BlackCounter = 0;
        YellowCounter = 0;
        RedCounter = 0;
        BlueCounter = 0;
        hasStation = false;
        if (name == "Blue_Atlanta")
        {
            hasStation = true;
        }
        pieces = new List<GameObject>();
    }

    public void place()
    {
        if (pieces.Count == 1)
        {
            pieces[0].transform.position = transform.position;
        }
        else if (pieces.Count == 2)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.333333f, transform.position[1], transform.position[2]);
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.333333f, transform.position[1], transform.position[2]);
        }
        else if (pieces.Count == 3)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.288675f, transform.position[1] - 0.166667f, transform.position[2]);
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.288675f, transform.position[1] - 0.166667f, transform.position[2]);
            pieces[2].transform.position = new Vector3(transform.position[0], transform.position[1] + 0.333333f, transform.position[2]);
        }
        else if (pieces.Count == 4)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.235702f, transform.position[1] - 0.235702f, transform.position[2]);
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.235702f, transform.position[1] - 0.235702f, transform.position[2]);
            pieces[2].transform.position = new Vector3(transform.position[0] + 0.235702f, transform.position[1] + 0.235702f, transform.position[2]);
            pieces[3].transform.position = new Vector3(transform.position[0] - 0.235702f, transform.position[1] + 0.235702f, transform.position[2]);
        }
    }

}
