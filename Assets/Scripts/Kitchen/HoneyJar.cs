using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyJar : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameController.control.sweepablesCompleted) {
            GameController.control.playerHasJar = true;
            MusicManager.Instance.PauseHouse();
            GameController.control.foundItemSource.Play();
            DialogCanvas.Instance.QueueDialog("YOU GOT THE JAR OF HONEY.");
            DialogCanvas.Instance.QueueDialog("(There's already some flies stuck in here.)");
            DialogCanvas.Instance.QueueDialog("(Gross...)");
            DialogCanvas.Instance.SetOnAllDialogDismissed(MusicManager.Instance.UnPauseHouse);
            gameObject.SetActive(false);
        } else {
            DialogCanvas.Instance.QueueDialog("(This jar of honey has some flies stuck in it.)");
            DialogCanvas.Instance.QueueDialog("(*Gag*)");
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
