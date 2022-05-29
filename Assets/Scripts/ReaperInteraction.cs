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
            DialogCanvas.Instance.QueueDialog("Wow, thanks for all your help! I'm sorry I've been neglecting my job. Let me help you therough the gate now.");
            StartCoroutine(ExitHouse());
        }
        else 
        {
            DialogCanvas.Instance.QueueDialog("Hey there...");
        }
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }

    IEnumerator ExitHouse()
    {
        yield return new WaitForSeconds(2);
        GameController.control.lastScene = "Bedroom";
        SceneManager.LoadScene(sceneName: "EtherealRoad");
    }
}
