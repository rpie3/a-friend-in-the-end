using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour, IInteractable
{
    [SerializeField] private string dictionaryKey;
    
    public void Interact()
    {
        if (
            GameController.control.playerHasJar 
            && !GameController.control.flyTracker[dictionaryKey]
        ) {
            
            DialogCanvas.Instance.dialogBox.setDialogText("I caught a fly!");
            DialogCanvas.Instance.dialogBox.openDialog();
            GameController.control.onFlyCaught(dictionaryKey);
            gameObject.SetActive(false);

            if (dictionaryKey == "last")
            {
                DialogCanvas.Instance.dialogBox.setDialogText("Thanks for feeding the spiders!");
                DialogCanvas.Instance.dialogBox.openDialog();
            }
        } 
        else 
        {
            DialogCanvas.Instance.dialogBox.setDialogText("A fly? Buzz off!");
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
    {   if (dictionaryKey == "last" && !GameController.control.SecondToLastFlyCaught())
        {
            gameObject.SetActive(false);
        }

        if (GameController.control.fliesCompleted ||  GameController.control.flyTracker[dictionaryKey])
        {
            gameObject.SetActive(false);
        }
    }
}
