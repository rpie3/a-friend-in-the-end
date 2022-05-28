using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController control;

    [Header("Global Data")]
    public string lastScene;

    [Header("Ethereal Road Scene Data")]
    [SerializeField] public bool playerHasWateringCan = false;
    [SerializeField] public bool outdoorFlowersWatered = false;
    public int numberOfFlowersToWater = 1;
    public int numberOfFlowersWatered = 0;

    public void CheckIfLastFlower()
    {
        if (numberOfFlowersWatered >= numberOfFlowersToWater)
        {
            outdoorFlowersWatered = true;
            // trigger grim reapear coming out of house
        }
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