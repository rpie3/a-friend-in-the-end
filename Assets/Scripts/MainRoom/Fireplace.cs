using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        DialogCanvas.Instance.QueueDialog("The fire is roaring now...");
    }

    public void ShowHint()
    {

    }

    public void HideHint()
    {

    }
}
