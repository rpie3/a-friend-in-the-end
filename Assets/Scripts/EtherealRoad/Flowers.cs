using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour, IInteractable
{
    [SerializeField] EtherealRoad.LevelManager levelManager;
    [SerializeField] Animator animator;

    public void Interact()
    {
        if (
            GameController.control.playerHasWateringCan && 
            !animator.GetBool("hasBeenWatered")
        ) {
            animator.SetBool("hasBeenWatered", true);
            levelManager.OnFlowerWatered();
        } 
        else if (animator.GetBool("hasBeenWatered"))
        {
            DialogCanvas.Instance.dialogBox.setDialogText("They're looking great now!");
            DialogCanvas.Instance.dialogBox.openDialog();
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
