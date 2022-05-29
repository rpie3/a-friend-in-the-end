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
            DialogCanvas.Instance.dialogBox.setDialogText("You don't want to pass on? You want to stay and hang out with me? That's so great!!!");
            DialogCanvas.Instance.dialogBox.openDialog();
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        DialogCanvas.Instance.dialogBox.closeDialog();
        SceneManager.LoadScene(sceneName: "EndCredits");
    }
}
