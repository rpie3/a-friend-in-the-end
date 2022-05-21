using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SunRoom {    
    public class SunRoomDoor : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {   
                SceneManager.LoadScene(sceneName: "MainRoom");
            }
        }
    }
}
