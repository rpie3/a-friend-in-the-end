using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditsUI : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}