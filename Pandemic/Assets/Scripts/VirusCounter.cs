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
        if (gameObject.name == "RedCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().RedCounter.ToString();
        if (gameObject.name == "BlueCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().BlueCounter.ToString();
        if (gameObject.name == "YellowCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().YellowCounter.ToString();
        if (gameObject.name == "BlackCounter")
            GetComponent<TextMesh>().text = GetComponentInParent<City>().BlackCounter.ToString();
    }
}
