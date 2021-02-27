using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private bool isDragging = false;
    private bool isOverDropzone = false;
    private Vector2 startPosition;
    private GameObject DropZone;
    public const int c_max_dropzone = 6;
    // variabile per rendere invalidi i posizionamenti su se stessi
    private bool isSelfBody = false;

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
        isSelfBody = false;
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
        isSelfBody = true;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropzone && !isSelfBody)
        {
            if (DrawCards.n_dropzone_cards < c_max_dropzone) {
                transform.SetParent(DropZone.transform, false);

                // decrementa
                DrawCards.n_ally_cards = DrawCards.n_ally_cards - 1;
                Debug.Log("Numero carte alleate : " + (DrawCards.n_ally_cards + 1));

                //incrementa carte Dropzone
                DrawCards.n_dropzone_cards = DrawCards.n_dropzone_cards + 1;
                Debug.Log("Numero carte Dropzone : " + (DrawCards.n_dropzone_cards));
            }
            else
            {
                transform.position = startPosition;
                Debug.Log("Non puoi farlo!");
            }

        }
        else
        {
            transform.position = startPosition;
        }
    }

}
