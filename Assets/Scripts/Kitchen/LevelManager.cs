using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen {    
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject reaper;
        [SerializeField] public GameObject reaperCam;
        [SerializeField] public GameObject sandwich;
        [SerializeField] public GameObject completedSandwich;
        
        [Header("Ingredient Tracking")]
        [SerializeField] public int numberIngredientsNeeded = 3;
        [SerializeField] public int numberIngedientsCollected = 0;
        
        public void OnIngredientCollected()
        {
            numberIngedientsCollected++;
            CheckIfLastIngredient();
        }

        private void CheckIfLastIngredient()
        {
            if (
                numberIngedientsCollected >= numberIngredientsNeeded && 
                GameController.control.sandwichIngredientsCollected == false
            ) {
                GameController.control.sandwichIngredientsCollected = true;
                DialogCanvas.Instance.QueueDialog("This should be enough good stuff to make a  NICE SANDWICH!");
            } 
            else 
            {
                DialogCanvas.Instance.QueueDialog("I found an ingredient to make a NICE SANDWICH!");
            }
        }
        
        public void OnSandwichAssembled()
        {
            sandwich.SetActive(false);
            reaperCam.SetActive(true);
            completedSandwich.SetActive(true);
            StartCoroutine(InitiateReaperAppearance());
        }

        IEnumerator InitiateReaperAppearance()
        {
            yield return new WaitForSeconds(2);
            reaper.SetActive(true);

            DialogCanvas.Instance.QueueDialog("Oh wow! You made that for me? Thanks!");
            DialogCanvas.Instance.SetOnAllDialogDismissed(AfterSandwichDelivery);
        }

        public void AfterSandwichDelivery()
        {
            GameController.control.reaperHasReceivedSandwich = true;
            completedSandwich.SetActive(false);
            reaper.SetActive(false);
            reaperCam.SetActive(false);
        }
    }
}
