using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactionHint;

    public void ShowHint()
    {
        // Debug.Log("Present Interaction Option");
        interactionHint.SetActive(true);
    }

    public void HideHint()
    {
        // Debug.Log("Hide Interaction Option");
        interactionHint.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("You pressed light post button.");
        DialogCanvas.Instance.dialogBox.setDialogText("ZAP!");
        DialogCanvas.Instance.dialogBox.openDialog();
    }
}
