using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainRoom {
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject player;

        [Header("Exit & Entrance References")]
        [SerializeField] public GameObject frontDoor;
        [SerializeField] public GameObject sunRoomDoor;
        [SerializeField] public GameObject staircase;
        [SerializeField] public GameObject kitchenDoor;
        [SerializeField] public GameObject toiletDoor;

        [Header("Sweepable Tracking")]
        [SerializeField] public int numberToSweep = 2;
        [SerializeField] public int numberSwept = 0;

        public void OnDustPileSwept()
        {
            numberSwept++;
            CheckIfLastSweepable();
        }

        private void CheckIfLastSweepable()
        {
             if (
                numberSwept >= numberToSweep && 
                GameController.control.sweepablesCompleted == false
            ) {
                GameController.control.sweepablesCompleted = true;
                // onAllFlowersWatered.Invoke();
                // houseCam.SetActive(true);
                // StartCoroutine(OpenDoor());
            }
        }

        private void spawnPlayerInsideFrontDoor()
        {
            player.transform.position = new Vector2(frontDoor.transform.position.x, frontDoor.transform.position.y + 2);
        }

        private void spawnPlayerInsideSunRoomDoor()
        {
            player.transform.position = new Vector2(sunRoomDoor.transform.position.x - 2, sunRoomDoor.transform.position.y);
        }

        private void spawnPlayerInsideStaircase()
        {
            player.transform.position = new Vector2(staircase.transform.position.x, staircase.transform.position.y - 2);
        }

        private void spawnPlayerInsideKitchenDoor()
        {
            player.transform.position = new Vector2(kitchenDoor.transform.position.x + 2, kitchenDoor.transform.position.y);
        }

        private void spawnPlayerInsideToiletDoor()
        {
            player.transform.position = new Vector2(toiletDoor.transform.position.x + 2, toiletDoor.transform.position.y);
        }

        void Start()
        {
            // Debug.Log("MainRoom LevelManager shows lastScene as " + GameController.control.lastScene);
            if (GameController.control.lastScene == "EtherealRoad")
            {
                spawnPlayerInsideFrontDoor();
            }
            if (GameController.control.lastScene == "SunRoom")
            {
                spawnPlayerInsideSunRoomDoor();
            }
            if (GameController.control.lastScene == "Bedroom")
            {
                spawnPlayerInsideStaircase();
            }
            if (GameController.control.lastScene == "Kitchen")
            {
                spawnPlayerInsideKitchenDoor();
            }
            if (GameController.control.lastScene == "Toilet")
            {
                spawnPlayerInsideToiletDoor();
            }
        }
    }
}
