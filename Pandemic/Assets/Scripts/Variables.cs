using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public Vector3 position = new Vector3(-462, 117, 0);

    public string prevCity = "Atlanta";
    public Dictionary<string, HashSet<string>> neighbors = new Dictionary<string, HashSet<string>>()
    {
        {"Atlanta", new HashSet<string> {"Chicago"} },
        {"Chicago", new HashSet<string> {"Atlanta", "Mexico City"} },
        {"Mexico City", new HashSet<string>{ "Chicago"} }
    };
}
