using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobweb : MonoBehaviour, IInteractable
{
    [SerializeField] MainRoom.LevelManager levelManager;
    private bool hasBeenSwept = false;

    public void Interact()
    {
        if (
            GameController.control.playerHasBroom 
            // && !animator.GetBool("hasBeenWatered")
            && !hasBeenSwept
        ) {
            // animator.SetBool("hasBeenWatered", true);
            hasBeenSwept = true;
            GameController.control.itemSweptSource.Play();
            levelManager.OnDustPileSwept();
            gameObject.SetActive(false);
        } 
        // else if (animator.GetBool("hasBeenWatered"))
        // {
        //     DialogCanvas.Instance.QueueDialog("They're looking great now!");
        //    
        // }
        else 
        {
            DialogCanvas.Instance.QueueDialog("(This room could really stand a sweeping...)");
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
        if (GameController.control.sweepablesCompleted)
        {
            gameObject.SetActive(false);
        }
    }
}
