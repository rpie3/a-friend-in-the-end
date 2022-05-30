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
            GameController.control.fliesCompleted
        ) {
            DialogCanvas.Instance.QueueDialog("Wow, you really helped me out!");
            DialogCanvas.Instance.QueueDialog("Sorry I've been dropping the ball on helping dead folks.");
            DialogCanvas.Instance.QueueDialog("Let's get you to the great beyond!");
            DialogCanvas.Instance.SetOnAllDialogDismissed(ExitHouse);
        }
        else 
        {
            DialogCanvas.Instance.QueueDialog("Oh...hey...");
            DialogCanvas.Instance.QueueDialog("Sorry things are such a mess...");
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
