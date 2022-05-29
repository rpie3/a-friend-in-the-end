using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource foundItem;

    public void Interact()
    {
        GameController.control.playerHasWateringCan = true;
        foundItem.Play();
        DialogCanvas.Instance.QueueDialog("I picked up a WATERING CAN!");
        gameObject.SetActive(false);
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }

    public void Start()
    {
        if (GameController.control.playerHasWateringCan)
        {
            gameObject.SetActive(false);
        }
    }
}
