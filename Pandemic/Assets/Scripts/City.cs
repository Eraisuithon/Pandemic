using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public short BlackCounter = 0; // Default value of int is 0
    public short YellowCounter = 0;
    public short RedCounter = 0;
    public short BlueCounter = 0;
    public bool hasStation; // Default value of bool is false
    public GameObject station;
    public List<GameObject> pieces = new List<GameObject>();
    void Awake()
    {
        if (name == "Blue_Atlanta")
        {
            hasStation = true;
        }
    }


    public void place()
    {
        if (pieces.Count == 1)
        {
            pieces[0].transform.position = transform.position;
            pieces[0].GetComponent<Piece>().position = pieces[0].transform.position;
        }
        else if (pieces.Count == 2)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.333333f, transform.position[1], transform.position[2]);
            pieces[0].GetComponent<Piece>().position = pieces[0].transform.position;
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.333333f, transform.position[1], transform.position[2]);
            pieces[1].GetComponent<Piece>().position = pieces[1].transform.position;
        }
        else if (pieces.Count == 3)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.288675f, transform.position[1] - 0.166667f, transform.position[2]);
            pieces[0].GetComponent<Piece>().position = pieces[0].transform.position;
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.288675f, transform.position[1] - 0.166667f, transform.position[2]);
            pieces[1].GetComponent<Piece>().position = pieces[1].transform.position;
            pieces[2].transform.position = new Vector3(transform.position[0], transform.position[1] + 0.333333f, transform.position[2]);
            pieces[2].GetComponent<Piece>().position = pieces[2].transform.position;
        }
        else if (pieces.Count == 4)
        {
            pieces[0].transform.position = new Vector3(transform.position[0] - 0.235702f, transform.position[1] - 0.235702f, transform.position[2]);
            pieces[0].GetComponent<Piece>().position = pieces[0].transform.position;
            pieces[1].transform.position = new Vector3(transform.position[0] + 0.235702f, transform.position[1] - 0.235702f, transform.position[2]);
            pieces[1].GetComponent<Piece>().position = pieces[1].transform.position;
            pieces[2].transform.position = new Vector3(transform.position[0] + 0.235702f, transform.position[1] + 0.235702f, transform.position[2]);
            pieces[2].GetComponent<Piece>().position = pieces[2].transform.position;
            pieces[3].transform.position = new Vector3(transform.position[0] - 0.235702f, transform.position[1] + 0.235702f, transform.position[2]);
            pieces[3].GetComponent<Piece>().position = pieces[3].transform.position;
        }
    }

}
