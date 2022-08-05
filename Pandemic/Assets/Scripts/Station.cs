using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public bool didMove;
    // Start is called before the first frame update
    void Start()
    {

        if (didMove == true)// in this case I manually assigned true so that I know it's in Atlanta
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

    }
}
