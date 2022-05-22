using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kitchen {    
    public class KitchenDoor : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                GameController.control.lastScene = "Kitchen";
                SceneManager.LoadScene(sceneName: "MainRoom");
            }
        }
    }
}
