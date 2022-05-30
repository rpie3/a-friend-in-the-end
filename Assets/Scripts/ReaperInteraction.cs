using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReaperInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (
            GameController.control.outdoorFlowersWatered &&
            GameController.control.sweepablesCompleted &&
            GameController.control.indoorFlowersWatered &&
            GameController.control.reaperHasReceivedSandwich &&
            GameController.control.fliesCompleted &&
            !GameController.control.reaperHasOpenedGate
        ) {
            DialogCanvas.Instance.QueueDialog("Wow, you really helped me out!");
            DialogCanvas.Instance.QueueDialog("Sorry I've been dropping the ball on helping dead folks.");
            DialogCanvas.Instance.QueueDialog("Let's get you to the great beyond!");
            DialogCanvas.Instance.SetOnAllDialogDismissed(ExitHouse);
        }
        else if (
            !GameController.control.reaperHasOpenedGate
        ) {
            DialogCanvas.Instance.QueueDialog("Oh...hey...");
            DialogCanvas.Instance.QueueDialog("Sorry things are such a mess...");
        }
        else
        {
            DialogCanvas.Instance.QueueDialog("Well, here we are! You're free to pass through to dimensions unknown.");
            DialogCanvas.Instance.QueueDialog("Unless you felt like staying a little longer...");
        }
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }

    public void ExitHouse()
    {
        GameController.control.lastScene = "Bedroom";
        SceneManager.LoadScene(sceneName: "EtherealRoad");
    }
}
