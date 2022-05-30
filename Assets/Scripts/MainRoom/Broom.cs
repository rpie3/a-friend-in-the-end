using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameController.control.playerHasBroom = true;
        GameController.control.foundItemSource.Play();
        DialogCanvas.Instance.QueueDialog("YOU GOT THE BROOM.");
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
