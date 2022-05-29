using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichBase : MonoBehaviour, IInteractable
{
    [SerializeField] Kitchen.LevelManager levelManager;
    [SerializeField] AudioSource foundItem;

    public void Interact()
    {
        if (
            GameController.control.sandwichIngredientsCollected && 
            !GameController.control.playerHasSandwich
        ) {
            foundItem.Play();
            DialogCanvas.Instance.QueueDialog("I've assembled a NICE SANDWICH!");
            levelManager.OnSandwichAssembled();
        } 
        else 
        {
            DialogCanvas.Instance.QueueDialog("I bet Mr. Reaper could use a sandwich... If I can just find some ingredients...");
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
