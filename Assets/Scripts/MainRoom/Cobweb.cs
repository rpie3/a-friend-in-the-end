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
            levelManager.OnDustPileSwept();
            gameObject.SetActive(false);
        } 
        // else if (animator.GetBool("hasBeenWatered"))
        // {
        //     DialogCanvas.Instance.dialogBox.setDialogText("They're looking great now!");
        //     DialogCanvas.Instance.dialogBox.openDialog();
        // }
        else 
        {
            DialogCanvas.Instance.dialogBox.setDialogText("Seems like nobody has swept up in a while...");
            DialogCanvas.Instance.dialogBox.openDialog();
        }
    }
    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }
}
