using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    
    [Header("Menu")]
    [SerializeField] AudioSource titleSource;

    public void PlayTitleMusic()
    {
        titleSource.Play();
    }

    public void FadeTitleMusic()
    {
        IEnumerator fadeOut = FadeOut(titleSource, 0.5f);
        StartCoroutine(fadeOut);
    }

    [Header("ChracterDeath")]
    [SerializeField] AudioSource grasslandThemeWithIntro;
    [SerializeField] AudioSource grasslandThemeNoIntro;
    [SerializeField] AudioSource grasslandThemeDead;

    public void PlayGrasslandTheme()
    {
        grasslandThemeWithIntro.Play();
        grasslandThemeNoIntro.PlayDelayed(grasslandThemeWithIntro.clip.length);
    }

    public void FadeGrasslandTheme()
    {
        IEnumerator fadeOut = FadeOut(grasslandThemeWithIntro, 0.5f);
        StartCoroutine(fadeOut);
    }

    public void FadeGrasslandThemeLoop()
    {
        IEnumerator fadeOut = FadeOut(grasslandThemeNoIntro, 0.5f);
        StartCoroutine(fadeOut);
    }

    public void PlayGrasslandThemeDead()
    {
        FadeGrasslandTheme();
        FadeGrasslandThemeLoop();
        grasslandThemeDead.Play();
    }

    public void FadeGrasslandThemeDead()
    {
        IEnumerator fadeOut = FadeOut(grasslandThemeDead, 0.5f);
        StartCoroutine(fadeOut);
    }
    
    [Header("EtherealRoad")]
    [SerializeField] AudioSource tunnelSource;

    public void PlayTunnel()
    {
        FadeGrasslandThemeDead();
        tunnelSource.Play();
    }

    public void PauseTunnel()
    {
        tunnelSource.Pause();
    }

    public void UnPauseTunnel()
    {
        tunnelSource.UnPause();
    }

    public void FadeTunnel()
    {
        IEnumerator fadeOut = FadeOut(tunnelSource, 0.5f);
        StartCoroutine(fadeOut);
    }

    [Header("InsideHouse")]
    [SerializeField] AudioSource houseSourceWithIntro;
    [SerializeField] AudioSource houseSourceNoIntro;

    public void PlayHouse()
    {
        FadeTunnel();
        houseSourceWithIntro.Play();
        houseSourceNoIntro.PlayDelayed(houseSourceWithIntro.clip.length);
    }

     public void PauseHouse()
    {
        houseSourceWithIntro.Pause();
        houseSourceNoIntro.Pause();
    }

    public void UnPauseHouse()
    {
        houseSourceWithIntro.UnPause();
        houseSourceNoIntro.UnPause();
    }

    public bool IsHouseMusicPlaying()
    {
        return houseSourceWithIntro.isPlaying || houseSourceNoIntro.isPlaying;
    }

    public void FadeHouseWithIntro()
    {
        IEnumerator fadeOut = FadeOut(houseSourceWithIntro, 0.5f);
        StartCoroutine(fadeOut);
    }

    public void FadeHouseNoIntro()
    {
        IEnumerator fadeOut = FadeOut(houseSourceNoIntro, 0.5f);
        StartCoroutine(fadeOut);
    }

    public void FadeInHouseWithIntro()
    {
        IEnumerator fadeIn = FadeIn(houseSourceWithIntro, 0.5f);
        StartCoroutine(fadeIn);
    }

    public void FadeInHouseNoIntro()
    {
        IEnumerator fadeIn = FadeIn(houseSourceNoIntro, 0.5f);
        StartCoroutine(fadeIn);
    }

    [Header("Reaper Theme")]
    [SerializeField] AudioSource reaperThemeSource;

    public void PlayReaper()
    {
        reaperThemeSource.Play();
    }

    public void FadeReaper()
    {
        IEnumerator fadeOut = FadeOut(reaperThemeSource, 0.5f);
        StartCoroutine(fadeOut);
    }

    [Header("SFX")]
    [SerializeField] AudioSource warpOutSource;
    [SerializeField] AudioSource warpInSource;

    public void PlayWarpOut()
    {
        warpOutSource.Play();
    }

    public void PlayWarpIn()
    {
        warpInSource.Play();
    }   

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume < 1) {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
