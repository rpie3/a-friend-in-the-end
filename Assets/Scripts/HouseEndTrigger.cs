using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEndTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (
            other.CompareTag("Player") &&
            GameController.control.outdoorFlowersWatered &&
            GameController.control.sweepablesCompleted &&
            GameController.control.indoorFlowersWatered &&
            GameController.control.reaperHasReceivedSandwich &&
            GameController.control.fliesCompleted &&
            GameController.control.reaperHasOpenedGate
        ) {   
            DialogCanvas.Instance.QueueDialog("Oh, you want to stay and hang out? That's great!");
            DialogCanvas.Instance.QueueDialog("I'll make us some sandwiches! I hope you like fly honey...");
            DialogCanvas.Instance.SetOnAllDialogDismissed(EndGame);
        }
    }

    public void EndGame()
    {
        DialogCanvas.Instance.CloseDialog();
        MusicManager.Instance.FadeReaper();
        MusicManager.Instance.FadeTunnel();
        MusicManager.Instance.FadeHouseWithIntro();
        MusicManager.Instance.FadeHouseNoIntro();
        SceneManager.LoadScene(sceneName: "EndCredits");
    }
}
