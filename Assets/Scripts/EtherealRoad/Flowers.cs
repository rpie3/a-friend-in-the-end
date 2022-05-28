using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;

    public void Interact()
    {
        if (GameController.control.playerHasWateringCan)
        {
            animator.SetBool("hasBeenWatered", true);
            GameController.control.numberOfFlowersWatered++;
            GameController.control.CheckIfLastFlower();
        }
        else
        {
            DialogCanvas.Instance.dialogBox.setDialogText("Seems like they haven't been watered in a while...");
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
        if (GameController.control.outdoorFlowersWatered)
        {
            int hash = Animator.StringToHash("Watered");
            animator.Play(hash, 0, 1.0f);
        }
    }
}
