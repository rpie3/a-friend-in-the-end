using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EtherealRoad {
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject player;
        [SerializeField] public GameObject frontDoor;
        [SerializeField] public GameObject reaper;
        
        [Header("Flower Tracking")]
        [SerializeField] UnityEvent onAllFlowersWatered;
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
                GameController.control.outdoorFlowersWatered == false
            ) {
                GameController.control.outdoorFlowersWatered = true;
                onAllFlowersWatered.Invoke();
                reaper.SetActive(true);
            }
        }

        private void spawnPlayerOutsideFrontDoor()
        {
            player.transform.position = new Vector2(frontDoor.transform.position.x, frontDoor.transform.position.y - 2);
        }

        void Start()
        {
            if (GameController.control.lastScene == "MainRoom")
            {
                spawnPlayerOutsideFrontDoor();
            }

            if (GameController.control.outdoorFlowersWatered)
            {
                numberOfFlowersWatered = numberOfFlowersToWater;
            }
        }
    }
}
