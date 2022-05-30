using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactionHint;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] GameObject playerGO;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject portal;
    [SerializeField] AudioSource electrocutionSfxSource;
    [SerializeField] AudioSource electrocutionSource;
    [SerializeField] CharacterDeath.LevelManager levelManager;

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
        if (levelManager.isPlayerDead) 
        {
            if (portal.active)
            {
                DialogCanvas.Instance.QueueDialog("(Yeah, right. Like I'm going to do that again.)");
            }
            return;
        }
        levelManager.isPlayerDead = true;

        StartCoroutine(AfterElectrocution());
        MusicManager.Instance.FadeGrasslandTheme();
        MusicManager.Instance.FadeGrasslandThemeLoop();

        interactionHint.SetActive(false);

        electrocutionSfxSource.Play();
        player.SetElectrocution(true);
        player.SetSuspendMovement(true);

        StartCoroutine(AfterZap());
    }

    IEnumerator AfterZap()
    {
        yield return new WaitForSeconds(electrocutionSfxSource.clip.length);
        player.SetElectrocution(false);
        electrocutionSource.Play();
    }

    IEnumerator AfterElectrocution()
    {
        yield return new WaitForSeconds(3);

        deadPlayer.transform.position = playerGO.transform.position;
        deadPlayer.SetActive(true);

        playerSpriteRenderer.color = new Color(0.13f, 0.94f, 0.92f);

        DialogCanvas.Instance.QueueDialog("(Guess that wasn't the safe thing to do after all.)");
        DialogCanvas.Instance.QueueDialog("(I think I'm dead, but now where am I supposed to go?)");
        DialogCanvas.Instance.SetOnAllDialogDismissed(OnDeathComplete);

        portal.SetActive(true);
    }

    public void OnDeathComplete()
    {
        player.SetSuspendMovement(false);
        MusicManager.Instance.PlayGrasslandThemeDead();
    }
}
