using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bedroom {    
    public class Staircase : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                GameController.control.lastScene = "Bedroom";
                SceneManager.LoadScene(sceneName: "MainRoom");
                MusicManager.Instance.FadeReaper();
                MusicManager.Instance.FadeInHouseWithIntro();
                MusicManager.Instance.FadeInHouseNoIntro();
            }
        }

        void Start()
        {
            MusicManager.Instance.FadeHouseWithIntro();
            MusicManager.Instance.FadeHouseNoIntro();
            MusicManager.Instance.PlayReaper();
        }
    }
}
