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
        interactionHint.SetActive(false);

        // TODO play zapping animation
        MusicManager.Instance.FadeGrasslandTheme();
        MusicManager.Instance.FadeGrasslandThemeLoop();
        electrocutionSource.Play();

        // TODO show or instantiate dead player sprite
        deadPlayer.SetActive(true);

        // TODO change player sprite to ghost
        playerSpriteRenderer.color = Color.blue;
        
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
