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
                DialogCanvas.Instance.QueueDialog("(I've got everything I need for a great sandwich!)");
            } 
            else 
            {
                DialogCanvas.Instance.QueueDialog("(This would go great in a sandwich!)");
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

            DialogCanvas.Instance.QueueDialog("Wow! You made that just for me? Thanks!");
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
