using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.Instance.FadeGrasslandThemeDead();
            SceneManager.LoadScene(sceneName: "EtherealRoad");
        }
    }
}
