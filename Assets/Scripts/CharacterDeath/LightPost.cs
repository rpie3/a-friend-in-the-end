using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactionHint;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject portal;
    [SerializeField] AudioSource electrocutionSource;

    public void ShowHint()
    {
        interactionHint.SetActive(true);
    }

    public void HideHint()
    {
        interactionHint.SetActive(false);
    }

    public void Interact()
    {
        // if (dead) 
        // {
        //     DialogCanvas.Instance.QueueDialog("(Yeah, right. Like I'm going to do that again.)");
        // }

        interactionHint.SetActive(false);

        // TODO play zapping animation
        MusicManager.Instance.FadeGrasslandTheme();
        MusicManager.Instance.FadeGrasslandThemeLoop();
        electrocutionSource.Play();

        // TODO show or instantiate dead player sprite
        deadPlayer.SetActive(true);

        // TODO change player sprite to ghost
        playerSpriteRenderer.color = Color.blue;

        DialogCanvas.Instance.QueueDialog("(Guess that wasn't the safe thing to do after all.)");
        DialogCanvas.Instance.QueueDialog("(I think I'm dead, but now where am I supposed to go?)");
        
        // TODO portal appears
        StartCoroutine(InitiatePortalAppearance());

        StartCoroutine(WaitForElectrocutionSound());
        
    }

    IEnumerator InitiatePortalAppearance()
    {
        yield return new WaitForSeconds(5);
        portal.SetActive(true);
    }

    IEnumerator WaitForElectrocutionSound()
    {
        yield return new WaitForSeconds(5);
        MusicManager.Instance.PlayGrasslandThemeDead();
    }
}
