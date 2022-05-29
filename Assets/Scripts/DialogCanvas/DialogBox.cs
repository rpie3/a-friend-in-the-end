using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] TextMeshProUGUI text;

    public void openDialog()
    {
        animator.SetBool("dialogIsOpen", true);
    }

    public void closeDialog()
    {
        animator.SetBool("dialogIsOpen", false);
    }

    public void setDialogText(string newText)
    {
        text.text = newText;
    }
}
