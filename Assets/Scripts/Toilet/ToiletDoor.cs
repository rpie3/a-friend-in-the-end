using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toilet {    
    public class ToiletDoor : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                GameController.control.lastScene = "Toilet";
                SceneManager.LoadScene(sceneName: "MainRoom");
            }
        }
    }
}