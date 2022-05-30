using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichBase : MonoBehaviour, IInteractable
{
    [SerializeField] Kitchen.LevelManager levelManager;
    
    public void Interact()
    {
        if (
            GameController.control.sandwichIngredientsCollected && 
            !GameController.control.playerHasSandwich
        ) {
            MusicManager.Instance.PauseHouse();
            GameController.control.foundItemSource.Play();
            DialogCanvas.Instance.QueueDialog("YOU GOT THE SANDWICH.");
            DialogCanvas.Instance.SetOnAllDialogDismissed(MusicManager.Instance.UnPauseHouse);
            levelManager.OnSandwichAssembled();
        } 
        else 
        {
            DialogCanvas.Instance.QueueDialog("(I bet a sandwich would cheer him up.)");
            DialogCanvas.Instance.QueueDialog("(But I'll need some more ingredients...)");
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
        if (
            GameController.control.reaperHasReceivedSandwich
        ) {
            gameObject.SetActive(false);
        }
    }
}
