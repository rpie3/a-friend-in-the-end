using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactionHint;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject portal;

    public void ShowHint()
    {
        // Debug.Log("Present Interaction Option");
        interactionHint.SetActive(true);
    }

    public void HideHint()
    {
        // Debug.Log("Hide Interaction Option");
        interactionHint.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("You pressed light post button.");
        interactionHint.SetActive(false);

        // play zapping animation

        // show or instantiate dead player sprite
        deadPlayer.SetActive(true);

        // change player sprite to ghost
        playerSpriteRenderer.color = Color.blue;
        
        // portal appears
        StartCoroutine(InitiatePortalAppearance());
    }

    IEnumerator InitiatePortalAppearance()
    {
        yield return new WaitForSeconds(5);
        portal.SetActive(true);
    }
}
