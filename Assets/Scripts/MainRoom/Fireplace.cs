using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        DialogCanvas.Instance.dialogBox.setDialogText("The fire is roaring now...");
        DialogCanvas.Instance.dialogBox.openDialog();
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }
}
