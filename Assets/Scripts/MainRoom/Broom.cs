using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameController.control.playerHasBroom = true;
        MusicManager.Instance.PauseHouse();
        GameController.control.foundItemSource.Play();
        DialogCanvas.Instance.QueueDialog("YOU GOT THE BROOM.");
        DialogCanvas.Instance.QueueDialog("(Say your prayers, dust and webs!)");
        DialogCanvas.Instance.SetOnAllDialogDismissed(MusicManager.Instance.UnPauseHouse);
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
