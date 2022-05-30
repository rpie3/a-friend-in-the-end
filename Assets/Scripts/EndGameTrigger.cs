using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            DialogCanvas.Instance.CloseDialog();
            MusicManager.Instance.FadeReaper();
            MusicManager.Instance.FadeTunnel();
            SceneManager.LoadScene(sceneName: "EndCredits");
        }
    }
}
