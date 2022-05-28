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