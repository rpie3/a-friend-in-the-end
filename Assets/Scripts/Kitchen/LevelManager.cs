using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen {    
    public class LevelManager : MonoBehaviour
    {
        [Header("GameObject References")]
        [SerializeField] public GameObject reaper;
        [SerializeField] public GameObject sandwich;
        
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
                DialogCanvas.Instance.dialogBox.setDialogText("This should be enough good stuff to make a sandwich!");
                DialogCanvas.Instance.dialogBox.openDialog();
            } 
            else 
            {
                DialogCanvas.Instance.dialogBox.setDialogText("I found an ingredient to make a NICE SANDWICH!");
                DialogCanvas.Instance.dialogBox.openDialog();
            }
        }
        
        public void OnSandwichAssembled()
        {
            StartCoroutine(InitiateReaperAppearance());
        }

        IEnumerator InitiateReaperAppearance()
        {
            yield return new WaitForSeconds(2);
            reaper.SetActive(true);

            DialogCanvas.Instance.dialogBox.setDialogText("Oh wow! You made that for me? Thanks!");
            DialogCanvas.Instance.dialogBox.openDialog();
            GameController.control.reaperHasReceivedSandwich = true;
            sandwich.SetActive(false);
            StartCoroutine(ReaperLeave());
        }

        IEnumerator ReaperLeave()
        {
            yield return new WaitForSeconds(2);
            reaper.SetActive(false);
        }
    }
}
