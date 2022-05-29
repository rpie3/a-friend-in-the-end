using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainRoom {
    public class FrontDoor : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                GameController.control.lastScene = "MainRoom";
                MusicManager.Instance.FadeHouseWithIntro();
                MusicManager.Instance.FadeHouseNoIntro();
                SceneManager.LoadScene(sceneName: "EtherealRoad");
            }
        }
    }
}
