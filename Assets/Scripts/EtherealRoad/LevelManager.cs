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

            DialogCanvas.Instance.dialogBox.setDialogText("Oh hey... Didn't realize I was supposed to come get you... etc...");
            DialogCanvas.Instance.dialogBox.openDialog();
            StartCoroutine(ReaperDialogLine2());
        }

        IEnumerator ReaperDialogLine2()
        {
            yield return new WaitForSeconds(3);
            DialogCanvas.Instance.dialogBox.setDialogText("Thanks for doing that... Haven't felt like myself in a while... etc...");
            DialogCanvas.Instance.dialogBox.openDialog();
            StartCoroutine(ReaperDialogLine3());
        }

        IEnumerator ReaperDialogLine3()
        {
            yield return new WaitForSeconds(3);
            DialogCanvas.Instance.dialogBox.setDialogText("Come on in if you want...");
            DialogCanvas.Instance.dialogBox.openDialog();
            StartCoroutine(ReaperLeaves());
        }

        IEnumerator ReaperLeaves()
        {
            yield return new WaitForSeconds(3);
            reaper.SetActive(false);
            frontDoor.isFrontDoorLocked = false;
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
        }
    }
}
