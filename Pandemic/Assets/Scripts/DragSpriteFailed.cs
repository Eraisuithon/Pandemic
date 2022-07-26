using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSpriteFailed : MonoBehaviour
{
    private bool isDragging;
    private GameObject piece;

    private void Awake()
    {
        isDragging = false;
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (isDragging) return;
        piece = collider.gameObject;
        collider.transform.position = gameObject.GetComponent<Transform>().position;
    }


    private void Update()
    {
        if (!isDragging || piece==null) return;
        Debug.Log(piece.transform);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - piece.transform.position;
        piece.transform.Translate(mousePosition);
    }
}
