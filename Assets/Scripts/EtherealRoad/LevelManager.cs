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
            DialogCanvas.Instance.QueueDialog("Oh...hello. Thanks for watering my flowers.");
            DialogCanvas.Instance.QueueDialog("I'm the grim reaper, but...");
            DialogCanvas.Instance.QueueDialog("I've been a little depressed lately.");
            DialogCanvas.Instance.QueueDialog("That's why I didn't come to get you after you died.");
            DialogCanvas.Instance.QueueDialog("Things are kind of falling apart around here.");
            DialogCanvas.Instance.QueueDialog("It'd be nice to have some help...");
            DialogCanvas.Instance.SetOnAllDialogDismissed(AfterReaperIntro);
        }

        public void AfterReaperIntro()
        {
            GameController.control.playerHasMetReaper = true;
            frontDoor.isFrontDoorLocked = false;
            reaper.SetActive(false);
            houseCam.SetActive(false);
        }

        private void spawnPlayerOutsideFrontDoor()
        {
            player.transform.position = new Vector2(frontDoor.transform.position.x, frontDoor.transform.position.y - 2);
            
        }

        private void spawnPlayerAndReaperByGate()
        {
            MusicManager.Instance.FadeReaper();
            player.transform.position = new Vector2(gate.transform.position.x - 1, gate.transform.position.y + 2);
            reaper.SetActive(true);
            reaper.transform.position = new Vector2(gate.transform.position.x + 1, gate.transform.position.y + 2);
            gate.SetActive(false);
            GameController.control.lastScene = "EtherealRoad";
            GameController.control.reaperHasOpenedGate = true;       
            StartCoroutine(ShowDialog());     
        }

        IEnumerator ShowDialog()
        {
            yield return new WaitForSeconds(1);
            DialogCanvas.Instance.QueueDialog("Well, here we are! You're free to pass through to dimensions unknown.");
            DialogCanvas.Instance.QueueDialog("Unless you felt like staying a little longer...");
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
                DialogCanvas.Instance.QueueDialog("(Whoa, that was weird.)");
                DialogCanvas.Instance.QueueDialog("(Where am I?)");
                DialogCanvas.Instance.QueueDialog("(I'd better take a look around.)");
            }
        }
    }
}
