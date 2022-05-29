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
            DialogCanvas.Instance.QueueDialog("I caught a fly!");
            GameController.control.onFlyCaught(dictionaryKey);
            gameObject.SetActive(false);

            if (dictionaryKey == "last")
            {
                DialogCanvas.Instance.QueueDialog("Thanks for feeding the spiders!");
            }
        } 
        else 
        {
            DialogCanvas.Instance.QueueDialog("A fly? Buzz off!");
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
