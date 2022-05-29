using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyJar : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameController.control.sweepablesCompleted) {
            GameController.control.playerHasJar = true;
            DialogCanvas.Instance.dialogBox.setDialogText("I picked up a JAR OF HONEY! This would work great for catching flies!");
            DialogCanvas.Instance.dialogBox.openDialog();
            gameObject.SetActive(false);
        } else {
            DialogCanvas.Instance.dialogBox.setDialogText("It's a JAR OF HONEY... It smells so sweet...");
            DialogCanvas.Instance.dialogBox.openDialog();
        }
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }

    public void Start()
    {
        if (GameController.control.playerHasJar)
        {
            gameObject.SetActive(false);
        }
    }
}
