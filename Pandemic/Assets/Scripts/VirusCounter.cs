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
        else if (transform.parent.name == "RedVirus" && Board.isRedEradicated ||
                 transform.parent.name == "BlueVirus" && Board.isBlueEradicated ||
                 transform.parent.name == "BlackVirus" && Board.isBlackEradicated ||
                 transform.parent.name == "YellowVirus" && Board.isYellowEradicated)
            GetComponent<TextMesh>().text = " X";
        else if (transform.parent.name == "RedVirus" && Board.redVirusAvailable < 10)
            GetComponent<TextMesh>().text = " " + Board.redVirusAvailable.ToString();
        else if (transform.parent.name == "RedVirus")
            GetComponent<TextMesh>().text = Board.redVirusAvailable.ToString();
        else if (transform.parent.name == "BlueVirus" && Board.blueVirusAvailable < 10)
            GetComponent<TextMesh>().text = " " + Board.blueVirusAvailable.ToString();
        else if (transform.parent.name == "BlueVirus")
            GetComponent<TextMesh>().text = Board.blueVirusAvailable.ToString();
        else if (transform.parent.name == "YellowVirus" && Board.yellowVirusAvailable < 10)
            GetComponent<TextMesh>().text = " " + Board.yellowVirusAvailable.ToString();
        else if (transform.parent.name == "YellowVirus")
            GetComponent<TextMesh>().text = Board.yellowVirusAvailable.ToString();
        else if (transform.parent.name == "BlackVirus" && Board.blackVirusAvailable < 10)
            GetComponent<TextMesh>().text = " " + Board.blackVirusAvailable.ToString();
        else if (transform.parent.name == "BlackVirus")
            GetComponent<TextMesh>().text = Board.blackVirusAvailable.ToString();
    }
}
