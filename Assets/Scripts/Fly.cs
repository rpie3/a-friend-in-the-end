using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour, IInteractable
{
    [SerializeField] private string dictionaryKey;
    [SerializeField] public GameObject spiderCam;
    
    public void Interact()
    {
        if (
            GameController.control.playerHasJar 
            && !GameController.control.flyTracker[dictionaryKey]
        ) {
            DialogCanvas.Instance.QueueDialog("(I caught a fly!)");
            GameController.control.onFlyCaught(dictionaryKey);

            if (dictionaryKey == "last")
            {
                if (spiderCam != null)
                {
                    DialogCanvas.Instance.QueueDialog("(Man, this thing is huge!)");
                    DialogCanvas.Instance.QueueDialog("(The spiders should be happy now!)");
                    DialogCanvas.Instance.SetOnAllDialogDismissed(StartSpiderCutScene);
                }
                else
                {
                    DialogCanvas.Instance.QueueDialog("Thanks for feeding the spiders!");
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        } 
        else 
        {
            DialogCanvas.Instance.QueueDialog("(I don't have anything to catch it with!)");
        }
    }

    public void StartSpiderCutScene()
    {
        spiderCam.SetActive(true);
        StartCoroutine(SpiderDialogue());
    }

    IEnumerator SpiderDialogue()
    {
        yield return new WaitForSeconds(2);
        DialogCanvas.Instance.QueueDialog("Thanks for feeding the spiders!");
        DialogCanvas.Instance.SetOnAllDialogDismissed(OnSpiderCutSceneEnd);
    }

    public void OnSpiderCutSceneEnd()
    {
        spiderCam.SetActive(false);
        gameObject.SetActive(false);
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
