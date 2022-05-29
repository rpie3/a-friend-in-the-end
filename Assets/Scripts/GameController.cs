using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController control;

    [Header("Global Data")]
    public string lastScene;

    [Header("Ethereal Road Scene Data")]
    public bool playerHasWateringCan = false;
    public bool outdoorFlowersWatered = false;
    public bool playerHasMetReaper = false;

    [Header("Main Room Scene Data")]
    public bool playerHasBroom = false;
    public bool sweepablesCompleted = false;

    [Header("Sun Room Scene Data")]
    public bool indoorFlowersWatered = false;

    [Header("Kitchen Scene Data")]
    public bool sandwichIngredientsCollected = false;
    public bool playerHasSandwich = false;
    public bool reaperHasReceivedSandwich = false;

    [Header("Flies Tracking")]
    public bool playerHasJar = false;
    public bool fliesCompleted = false;

    [Header("End Game Info")]
    public bool reaperHasOpenedGate = false;

    public Dictionary<string, bool> flyTracker = new Dictionary<string, bool>() {
        {"first", false},
        {"second", false},
        {"third", false},
        {"fourth", false},
        {"last", false},
    };

    public bool SecondToLastFlyCaught()
    {
        if (
            flyTracker["first"] &&
            flyTracker["second"] &&
            flyTracker["third"] &&
            flyTracker["fourth"] &&
            !flyTracker["last"]
        ) {
            return true;
        }
        return false;
    }

    public void onFlyCaught(string dictionaryKey)
    {
        flyTracker[dictionaryKey] = true;

        if (SecondToLastFlyCaught())
        {
            DialogCanvas.Instance.dialogBox.setDialogText("If you can get one more, the spiders should have enough to eat...");
            DialogCanvas.Instance.dialogBox.openDialog();
        }

        if (dictionaryKey == "last")
        {
            fliesCompleted = true;
        }
    }

    public void ResetAllFields()
    {
        lastScene = "";
        playerHasWateringCan = false;
        outdoorFlowersWatered = false;
        playerHasMetReaper = false;

        playerHasBroom = false;
        sweepablesCompleted = false;

        indoorFlowersWatered = false;

        sandwichIngredientsCollected = false;
        playerHasSandwich = false;
        reaperHasReceivedSandwich = false;

        playerHasJar = false;
        fliesCompleted = false;

        reaperHasOpenedGate = false;

        flyTracker["first"] = false;
        flyTracker["second"] = false;
        flyTracker["third"] = false;
        flyTracker["fourth"] = false;
        flyTracker["last"] = false;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}