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
    public int fliesCaught = 0;

    [Header("End Game Info")]
    public bool reaperHasOpenedGate = false;

    [Header("Fly Sounds")]
    [SerializeField] AudioSource firstFlySource;
    [SerializeField] AudioSource secondFlySource;
    [SerializeField] AudioSource thirdFlySource;
    [SerializeField] AudioSource fourthFlySource;
    [SerializeField] AudioSource fifthFlySource;

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
        fliesCaught++; 

        flyTracker[dictionaryKey] = true;

        if (fliesCaught == 1) 
        {
            firstFlySource.Play();
        }
        if (fliesCaught == 2) 
        {
            secondFlySource.Play();
        }
        if (fliesCaught == 3) 
        {
            thirdFlySource.Play();
        }
        if (fliesCaught == 4) 
        {
            fourthFlySource.Play();
        }
        if (fliesCaught == 5) 
        {
            fifthFlySource.Play();
        }

        if (SecondToLastFlyCaught())
        {
            DialogCanvas.Instance.QueueDialog("If you can get one more, the spiders should have enough to eat...");
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