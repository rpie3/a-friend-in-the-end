using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunRoom {    
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject reaper;
        [SerializeField] public GameObject reaperCam;
        
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
                reaperCam.SetActive(true);
                StartCoroutine(InitiateReaperAppearance());
            }
        }

        IEnumerator InitiateReaperAppearance()
        {
            yield return new WaitForSeconds(2);
            reaper.SetActive(true);

            DialogCanvas.Instance.QueueDialog("Thanks for watering my plants!");
            DialogCanvas.Instance.QueueDialog("...but watch those fingers. Heh heh heh...");
            DialogCanvas.Instance.SetOnAllDialogDismissed(ReaperLeaves);
        }

        public void ReaperLeaves()
        {
            reaper.SetActive(false);
            reaperCam.SetActive(false);
        }

        void Start()
        {
            GameController.control.playerHasWateringCan = true;
        }
    }
}
