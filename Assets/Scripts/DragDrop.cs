using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private bool isDragging = false;
    private bool isOverDropzone = false;
    private Vector2 startPosition;
    private GameObject DropZone;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
        isOverDropzone = true;
        DropZone = collider.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger uscito!");
        isOverDropzone = false;
        DropZone = null;
    }
    /*

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropzone = true;
        DropZone = collision.gameObject;
        Debug.Log("Collision entrato!");
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropzone = false;
        Debug.Log("Collision uscito!");
        DropZone = null;
    }
    */

    // Start is called before the first frame update
    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropzone)
        {
            transform.SetParent(DropZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
        }
    }

}
