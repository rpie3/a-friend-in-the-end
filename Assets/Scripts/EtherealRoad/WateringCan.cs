using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameController.control.playerHasWateringCan = true;
        GameController.control.foundItemSource.Play();
        DialogCanvas.Instance.QueueDialog("YOU GOT THE WATERING CAN.");
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
