using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public bool inACity; // Default value of bool is false
    public Vector2 position;
    public bool didMove;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

        if (inACity == true)// in this case I manually assigned true to inACity so that I know it's in Atlanta
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

    }
}
