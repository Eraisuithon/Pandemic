using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public bool inACity;
    public Vector2 position;
    public bool didMove;
    // Start is called before the first frame update
    void Start()
    {
        inACity = false;
        position = transform.position;
        didMove = false;
    }
}
