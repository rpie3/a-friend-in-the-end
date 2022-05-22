using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionZone : MonoBehaviour
{
    IInteractable interactable;

    void OnTriggerEnter2D(Collider2D other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();
        
        if (interactable != null) 
        {
            // Debug.Log("Can interact with: " + other.name);          
            interactable.ShowHint();
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();
        
        if (interactable != null) 
        {
            // Debug.Log("Leaving ability to interact with: " + other.name);          
            interactable.HideHint();
        }
        
        interactable = null;
    }

    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
        {
            if (interactable != null) 
            {
                interactable.Interact();
            }
        }
    }
}
