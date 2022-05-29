using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyJar : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameController.control.sweepablesCompleted) {
            GameController.control.playerHasJar = true;
            DialogCanvas.Instance.QueueDialog("I picked up a JAR OF HONEY! This would work great for catching flies!");
            gameObject.SetActive(false);
        } else {
            DialogCanvas.Instance.QueueDialog("It's a JAR OF HONEY... It smells so sweet...");
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
