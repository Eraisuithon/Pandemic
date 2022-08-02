using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragVirus : MonoBehaviour
{
    [SerializeField]
    private GameObject city;


    private void Start()
    {
    }

    public void OnMouseDown()
    {
        if (GetComponent<Virus>().inACity)
        {
            transform.position = GetComponent<Virus>().startingPosition;
            GetComponent<Virus>().inACity = false;
            city.GetComponent<City>().RedCounter--;
            return;
        }
        if (city.GetComponent<City>().RedCounter == 3) return;
        transform.position = city.transform.position;
        GetComponent<Virus>().inACity = true;
        city.GetComponent<City>().RedCounter++;
    }
}
