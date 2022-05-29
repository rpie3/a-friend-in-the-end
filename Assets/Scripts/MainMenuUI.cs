using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        MusicManager.Instance.FadeTitleMusic();
        SceneManager.LoadScene(sceneName: "CharacterDeath");
    }

    void Start()
    {
        MusicManager.Instance.PlayTitleMusic();
        GameController.control.ResetAllFields();
    }
}
