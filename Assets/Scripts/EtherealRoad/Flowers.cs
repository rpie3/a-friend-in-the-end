using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
            DialogCanvas.Instance.QueueDialog("They're looking great now!");
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
        if (GameController.control.outdoorFlowersWatered)
        {
            int hash = Animator.StringToHash("Watered");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
