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
            DialogCanvas.Instance.QueueDialog("(Plants with teeth? Spooky!)");
           
        }
        else 
        {
            DialogCanvas.Instance.QueueDialog("(Looks like they could use some water.)");
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
            animator.SetBool("hasBeenWatered", true);
            int hash = Animator.StringToHash("Watered");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
