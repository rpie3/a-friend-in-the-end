using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour, IInteractable
{
    [SerializeField] EtherealRoad.LevelManager levelManager;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    public void Interact()
    {
        if (
            GameController.control.playerHasWateringCan && 
            !animator.GetBool("hasBeenWatered")
        ) {
            animator.SetBool("hasBeenWatered", true);
            audioSource.Play();
            levelManager.OnFlowerWatered();
        } 
        else if (animator.GetBool("hasBeenWatered"))
        {
            DialogCanvas.Instance.QueueDialog("(They're looking great now!)");
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
        if (GameController.control.outdoorFlowersWatered)
        {
            animator.SetBool("hasBeenWatered", true);
            int hash = Animator.StringToHash("Watered");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
