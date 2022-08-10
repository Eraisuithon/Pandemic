using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (name == "RedCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().RedCounter.ToString();
        else if (name == "BlueCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().BlueCounter.ToString();
        else if (name == "YellowCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().YellowCounter.ToString();
        else if (name == "BlackCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().BlackCounter.ToString();
        else if (transform.parent.name == "RedVirus")
            GetComponent<TextMesh>().text = Board.redVirusAvailable.ToString() + 'x';
        else if (transform.parent.name == "BlueVirus")
            GetComponent<TextMesh>().text = Board.blueVirusAvailable.ToString() + 'x';
        else if (transform.parent.name == "YellowVirus")
            GetComponent<TextMesh>().text = Board.yellowVirusAvailable.ToString() + 'x';
        else if (transform.parent.name == "BlackCounter")
            GetComponent<TextMesh>().text = Board.blackVirusAvailable.ToString() + 'x';
    }
}
