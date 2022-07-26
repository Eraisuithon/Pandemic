using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private bool isDragging;
    private bool centerPosition;

    public void OnMouseDown()
    {
        isDragging = true;
        centerPosition = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isDragging || !centerPosition) { return; }
        centerPosition = false;
        gameObject.GetComponent<RectTransform>().position = collider.transform.position;
    }


    private void Update()
    {
        if (!isDragging) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
