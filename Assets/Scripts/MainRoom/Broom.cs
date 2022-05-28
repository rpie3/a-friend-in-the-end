using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameController.control.playerHasBroom = true;
        DialogCanvas.Instance.dialogBox.setDialogText("I picked up a BROOM!");
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
        if (GameController.control.playerHasBroom)
        {
            gameObject.SetActive(false);
        }
    }
}
