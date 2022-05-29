using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichIngredient : MonoBehaviour, IInteractable
{
    [SerializeField] Kitchen.LevelManager levelManager;

    public void Interact()
    {
        levelManager.OnIngredientCollected();
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
        if (
            GameController.control.reaperHasReceivedSandwich
        ) {
            gameObject.SetActive(false);
        }
    }

}
