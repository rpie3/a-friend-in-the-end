using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PottedFlower : MonoBehaviour, IInteractable
{
    [SerializeField] SunRoom.LevelManager levelManager;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource growSource;

    public void Interact()
    {
        if (
            GameController.control.playerHasWateringCan 
            && !animator.GetBool("hasBeenWatered")
        ) {
            animator.SetBool("hasBeenWatered", true);
            growSource.Play();
            levelManager.OnFlowerWatered();
        } 
        else if (animator.GetBool("hasBeenWatered"))
        {
            DialogCanvas.Instance.QueueDialog("I've never seen plants with teeth before...");
           
        }
        else 
        {
            DialogCanvas.Instance.QueueDialog("Seems like they haven't been watered in a while...");
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
        if (GameController.control.indoorFlowersWatered)
        {
            int hash = Animator.StringToHash("Watered");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
