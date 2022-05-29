using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunRoom {    
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        
        [Header("Flower Tracking")]
        [SerializeField] public int numberOfFlowersToWater = 1;
        [SerializeField] public int numberOfFlowersWatered = 0;
        
        public void OnFlowerWatered()
        {
            numberOfFlowersWatered++;
            CheckIfLastFlower();
        }

        private void CheckIfLastFlower()
        {
            if (
                numberOfFlowersWatered >= numberOfFlowersToWater && 
                GameController.control.indoorFlowersWatered == false
            ) {
                GameController.control.indoorFlowersWatered = true;
                DialogCanvas.Instance.QueueDialog("Thanks for watering my more exotic plants... They love the attention...");
            }
        }

        void Start()
        {
            GameController.control.playerHasWateringCan = true;
        }
    }
}
