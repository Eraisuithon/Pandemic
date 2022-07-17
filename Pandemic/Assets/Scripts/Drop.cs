using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            string prevCity = eventData.pointerDrag.GetComponent<Variables>().prevCity;
            string newCity = gameObject.name;
            if (eventData.pointerDrag.GetComponent<Variables>().neighbors[prevCity].Contains(newCity))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                eventData.pointerDrag.GetComponent<Variables>().position = GetComponent<RectTransform>().position;
                eventData.pointerDrag.GetComponent<Variables>().prevCity = newCity;
            }
        }
    }
}
