using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameController.control.playerHasWateringCan = true;
        DialogCanvas.Instance.dialogBox.setDialogText("I picked up a WATERING CAN!");
        DialogCanvas.Instance.dialogBox.openDialog();
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
