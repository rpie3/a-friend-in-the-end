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
            DialogCanvas.Instance.dialogBox.setDialogText("I've assembled a NICE SANDWICH!");
            DialogCanvas.Instance.dialogBox.openDialog();
            levelManager.OnSandwichAssembled();
        } 
        else 
        {
            DialogCanvas.Instance.dialogBox.setDialogText("I bet Mr. Reaper could use a sandwich... If I can just find some ingredients...");
            DialogCanvas.Instance.dialogBox.openDialog();
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
            GameController.control.sandwichIngredientsCollected &&
            GameController.control.playerHasSandwich &&
            GameController.control.reaperHasReceivedSandwich
        ) {
            gameObject.SetActive(false);
        }
    }
}
