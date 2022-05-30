using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EtherealRoad {
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject player;
        [SerializeField] public GameObject reaper;
        [SerializeField] public House house;
        [SerializeField] public FrontDoor frontDoor;
        [SerializeField] public GameObject houseCam;
        [SerializeField] public GameObject gate;
        
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
                houseCam.SetActive(true);
                StartCoroutine(OpenDoor());
            }
        }

        IEnumerator OpenDoor()
        {
            yield return new WaitForSeconds(3);
            house.OpenDoor();
            StartCoroutine(InitiateReaperAppearance());
        }

        IEnumerator InitiateReaperAppearance()
        {
            yield return new WaitForSeconds(1);
            reaper.SetActive(true);

            DialogCanvas.Instance.QueueDialog("Oh hey... Didn't realize I was supposed to come get you... etc...");
            DialogCanvas.Instance.QueueDialog("Thanks for doing that... Haven't felt like myself in a while... etc...");
            DialogCanvas.Instance.QueueDialog("Come on in if you want...");
            
            // TODO add an on exit to dialog system for this action
            GameController.control.playerHasMetReaper = true;
            frontDoor.isFrontDoorLocked = false;
            reaper.SetActive(false);
        }

        private void spawnPlayerOutsideFrontDoor()
        {
            player.transform.position = new Vector2(frontDoor.transform.position.x, frontDoor.transform.position.y - 2);
        }

        private void spawnPlayerAndReaperByGate()
        {
            player.transform.position = new Vector2(gate.transform.position.x - 1, gate.transform.position.y + 2);
            reaper.SetActive(true);
            reaper.transform.position = new Vector2(gate.transform.position.x + 1, gate.transform.position.y + 2);
            gate.SetActive(false);
            GameController.control.lastScene = "EtherealRoad";
            GameController.control.reaperHasOpenedGate = true;
        }

        void Start()
        {
            MusicManager.Instance.PlayTunnel();
            
            if (GameController.control.lastScene == "MainRoom")
            {
                spawnPlayerOutsideFrontDoor();
            }

            if (GameController.control.lastScene == "Bedroom")
            {
                spawnPlayerAndReaperByGate();
            }

            if (GameController.control.outdoorFlowersWatered)
            {
                numberOfFlowersWatered = numberOfFlowersToWater;
            }

            if (GameController.control.playerHasMetReaper)
            {
                frontDoor.isFrontDoorLocked = false;
            }
            else 
            {
                DialogCanvas.Instance.QueueDialog("(I think I just died!)");
                DialogCanvas.Instance.QueueDialog("(Where am I?)");
            }
        }
    }
}
